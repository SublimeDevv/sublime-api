# Sublime API

Backend desarrollado con **ASP.NET 9** siguiendo los principios de **Arquitectura Limpia (Clean Architecture)**. Utiliza un mediador propio, versionado de API, autenticacion JWT mediante cookies HttpOnly, FluentValidation, y Entity Framework Core con dos contextos de base de datos separados.

---

## Tabla de contenidos

- [Estructura de la solucion](#estructura-de-la-solucion)
- [Capas](#capas)
  - [Base.Domain](#basedomain)
  - [Base.Application](#baseapplication)
  - [Base.Identity](#baseidentity)
  - [Base.Infraestructure](#baseinfraestructure)
  - [Base.API](#baseapi)
  - [Base.Test](#basetest)
- [Conceptos clave](#conceptos-clave)
- [Configuracion inicial](#configuracion-inicial)
- [Tutorial: agregar un nuevo modulo](#tutorial-agregar-un-nuevo-modulo)
- [Autorizacion basada en roles](#autorizacion-basada-en-roles)

---

## Estructura de la solucion

```
Base.sln
├── Base.Domain
├── Base.Application
├── Base.Identity
├── Base.Infraestructure
├── Base.API
└── Base.Test
```

El flujo de dependencias respeta la regla de dependencia de Clean Architecture: las capas externas dependen de las internas, nunca al reves.

```
Base.API
    └── Base.Application  <──  Base.Identity
              └── Base.Domain
                      ^
            Base.Infraestructure
```

---

## Capas

### Base.Domain

Nucleo del sistema. No tiene dependencias externas.

- **Entities**: clases de dominio con logica de negocio encapsulada y constructores con guard clauses. Los IDs son UUIDv7.
- **ValueObjects**: objetos de valor inmutables definidos como `record` (ej. `Email`).

```
Base.Domain/
├── Entities/
│   ├── Product.cs
│   ├── Customer.cs
│   ├── Cart.cs
│   └── CartProduct.cs
└── ValueObjects/
    └── Email.cs
```

---

### Base.Application

Contiene toda la logica de aplicacion. Define contratos (interfaces) que las capas externas implementan.

- **UseCases**: cada caso de uso vive en su propia carpeta con un `Command`/`Query` y su `Handler`.
- **Contracts**: interfaces de repositorios, unidad de trabajo y notificaciones.
- **DTOs**: objetos de transferencia de datos para las respuestas.
- **Validators**: validaciones con FluentValidation. Se registran automaticamente y se ejecutan antes de cada handler.
- **Exceptions**: excepciones de dominio (`BusinessRuleException`, `NotFoundException`, etc.).
- **Utils/Mediator**: implementacion propia del patron mediador.
- **Utils/Commons**: clases de utilidad como `PagedResult<T>` y `PagedQueryDto`.

```
Base.Application/
├── Contracts/
│   ├── Repositories/
│   │   ├── IRepository.cs
│   │   ├── Auth/
│   │   │   ├── IUserRepository.cs
│   │   │   ├── ITokenRepository.cs
│   │   │   └── IRoleRepository.cs
│   │   └── Products/
│   ├── Persistence/
│   │   └── IUnitOfWork.cs
│   └── Notifications/
│       └── IServiceNotifications.cs
├── DTOs/
├── Exceptions/
├── UseCases/
│   ├── Auth/
│   │   ├── Commands/
│   │   │   ├── Login/
│   │   │   ├── Register/
│   │   │   ├── Logout/
│   │   │   ├── RefreshToken/
│   │   │   ├── ForgotPassword/
│   │   │   ├── ResetPassword/
│   │   │   ├── CreateRole/
│   │   │   ├── DeleteRole/
│   │   │   ├── AssignRole/
│   │   │   └── RemoveRole/
│   │   └── Queries/
│   │       ├── GetCurrentUser/
│   │       └── GetRoles/
│   └── Products/
├── Utils/
│   ├── Mediator/
│   ├── Commons/
│   └── Pager/
└── Validators/
```

#### Mediador propio

En lugar de MediatR, el proyecto incluye su propio mediador. Al llamar a `_mediator.Send(request)` ocurre lo siguiente:

1. Se busca el validador de FluentValidation asociado al request (si existe) y se ejecuta.
2. Se resuelve el handler correspondiente mediante el contenedor de DI.
3. Se invoca `Handle(request)` y se retorna el resultado.

Los handlers y validadores se registran automaticamente mediante **Scrutor** al escanear el ensamblado en `Base.Application/DependencyInjection.cs`. No es necesario registrarlos manualmente.

#### Repositorio generico

`IRepository<T>` expone las operaciones basicas:

```csharp
Task<IEnumerable<T>> GetAll();
Task<T?> GetByIdAsync(Guid id);
Task<T> AddAsync(T entity);
Task UpdateAsync(T entity);
Task DeleteAsync(T entity);
Task<int> GetTotalCount();
```

Los repositorios especificos extienden esta interfaz para agregar consultas propias.

---

### Base.Identity

Capa dedicada exclusivamente a la autenticacion y autorizacion.

- Usa **ASP.NET Identity** con un `IdentityDbContext` propio separado del contexto de la aplicacion.
- Gestiona usuarios (`User`), roles (`IdentityRole`), tokens JWT y refresh tokens (`RefreshToken`).
- Los tokens JWT se almacenan y leen desde **cookies HttpOnly + Secure**, nunca se exponen en el cuerpo de la respuesta.
- Los roles del usuario se incluyen como claims en el JWT al momento de generarlo, de modo que `[Authorize(Roles = "...")]` funciona sin consultas adicionales a la base de datos.
- Implementa `IUserRepository`, `ITokenRepository` e `IRoleRepository` definidos en `Base.Application`.

```
Base.Identity/
├── IdentityDbContext.cs
├── DependencyInjection.cs
├── Models/
│   ├── User.cs
│   └── RefreshToken.cs
├── Repositories/
│   ├── UserRepository.cs
│   ├── TokenRepository.cs
│   └── RoleRepository.cs
└── Settings/
    └── JwtSettings.cs
```

#### Autorizacion basada en roles

El sistema de roles esta construido sobre ASP.NET Identity y se integra transparentemente con los tokens JWT.

**Como funcionan los roles:**

1. Al hacer login o register, el repositorio consulta los roles del usuario y los incluye como claims `ClaimTypes.Role` dentro del JWT.
2. ASP.NET lee esos claims al validar el token; no se requiere ninguna consulta adicional a la base de datos por request.
3. Los controladores y acciones usan `[Authorize(Roles = "NombreRol")]` para restringir el acceso.

**Contratos en Base.Application:**

`IRoleRepository` expone la gestion de roles:

```csharp
Task<IList<string>> GetAllRolesAsync();
Task CreateRoleAsync(string roleName);
Task DeleteRoleAsync(string roleName);
Task<bool> RoleExistsAsync(string roleName);
```

`IUserRepository` expone la asignacion y consulta de roles por usuario:

```csharp
Task AssignRoleAsync(string userId, string roleName);
Task RemoveRoleAsync(string userId, string roleName);
Task<IList<string>> GetUserRolesAsync(string userId);
```

**Endpoint de gestion de roles (`/api/v1/role`):**

Todo el controlador esta protegido con `[Authorize(Roles = "Admin")]`; solo usuarios con ese rol pueden acceder.

| Metodo | Ruta | Descripcion |
|---|---|---|
| `GET` | `/api/v1/role` | Lista todos los roles existentes |
| `POST` | `/api/v1/role` | Crea un nuevo rol |
| `POST` | `/api/v1/role/assign` | Asigna un rol a un usuario |
| `POST` | `/api/v1/role/remove` | Quita un rol de un usuario |
| `DELETE` | `/api/v1/role/{roleName}` | Elimina un rol |

**Como proteger un controlador o accion:**

```csharp
// Solo usuarios autenticados (cualquier rol)
[Authorize]
public class OrderController : ControllerBase { }

// Solo usuarios con el rol "Admin"
[Authorize(Roles = "Admin")]
public class RoleController : ControllerBase { }

// Multiples roles aceptados (OR)
[Authorize(Roles = "Admin,Manager")]
public IActionResult SomeAction() { }
```

> Si un usuario autenticado intenta acceder a un endpoint para el que no tiene el rol requerido, ASP.NET retorna automaticamente `403 Forbidden`. Este caso no pasa por el `GlobalExceptionHandler`.

---

### Base.Infraestructure

Implementacion de persistencia de datos para las entidades de dominio.

- `ApplicationDbContext`: contexto de EF Core para las entidades de dominio. Las configuraciones de cada entidad se aplican automaticamente desde el ensamblado.
- `BaseRepository<T>`: implementacion generica de `IRepository<T>`.
- Los repositorios especificos heredan de `BaseRepository<T>` e implementan la interfaz correspondiente de `Base.Application`.
- `UnitOfWorkEF`: envuelve `SaveChangesAsync` para exponer `Commit()` y `Rollback()`.
- `EmailService`: envio de correos via SMTP.

```
Base.Infraestructure/
├── ApplicationDbContext.cs
├── DependendyInjection.cs
├── Configurations/
├── Migrations/
├── Notifications/
├── Repositories/
│   ├── BaseRepository.cs
│   └── Products/
├── UnitsOfWork/
└── Utils/
    └── IQueryableExtentions.cs
```

> Nota: existen dos bases de datos de migraciones independientes. Una para el contexto de identidad (`Base.Identity/Migrations`) y otra para el contexto de aplicacion (`Base.Infraestructure/Migrations`). Ambas apuntan a la misma base de datos SQL Server.

---

### Base.API

Capa de presentacion. Expone los endpoints HTTP y orquesta el flujo de entrada.

- Los controladores reciben el request, lo pasan al mediador y devuelven la respuesta HTTP. No contienen logica de negocio.
- El versionado de API usa el paquete `Asp.Versioning`. Los controladores se organizan en carpetas `v1/` y `v2/`.
- `GlobalExceptionHandler`: middleware que intercepta las excepciones de dominio y las mapea a respuestas HTTP con `ProblemDetails`.
- La proteccion de rutas se declara con `[Authorize]` (cualquier usuario autenticado) o `[Authorize(Roles = "NombreRol")]` (rol especifico) a nivel de controlador o accion.

```
Base.API/
├── Controllers/
│   ├── v1/
│   │   ├── AuthController.cs
│   │   ├── RoleController.cs
│   │   └── ProductController.cs
│   └── v2/
│       └── ProductController.cs
├── Middleware/
│   └── GlobalExceptionHandler.cs
├── DependencyInjection.cs
└── Program.cs
```

#### Endpoints de autenticacion (`/api/v1/auth`)

| Metodo | Ruta | Requiere auth | Descripcion |
|---|---|---|---|
| `POST` | `/api/v1/auth/register` | No | Registra un nuevo usuario y devuelve sus datos. Los tokens se escriben en cookies. |
| `POST` | `/api/v1/auth/login` | No | Autentica al usuario y escribe los tokens en cookies. |
| `POST` | `/api/v1/auth/refresh` | No (cookie) | Renueva el access token usando el refresh token de la cookie. |
| `POST` | `/api/v1/auth/logout` | Si | Revoca el refresh token y elimina las cookies. |
| `POST` | `/api/v1/auth/forgot-password` | No | Envia un correo con el enlace para restablecer la contrasena. |
| `POST` | `/api/v1/auth/reset-password` | No | Restablece la contrasena usando el token recibido por correo. |
| `GET` | `/api/v1/auth/me` | Si | Devuelve los datos del usuario autenticado actual. |

#### GlobalExceptionHandler

Implementa `IExceptionHandler` de ASP.NET. Cuando cualquier excepcion no controlada escapa de un handler o controlador, el middleware la intercepta, determina el codigo HTTP adecuado y escribe una respuesta uniforme en formato `ProblemDetails` con la siguiente forma:

```json
{
  "status": 400,
  "title": "Validation failed",
  "errors": ["El campo Name es requerido"]
}
```

La siguiente tabla describe como se mapea cada excepcion:

| Excepcion | Codigo HTTP | Titulo | Cuando usarla |
|---|---|---|---|
| `ValidationExceptionFluent` | `400 Bad Request` | `Validation failed` | La lanza el mediador automaticamente cuando un validador de FluentValidation falla. Incluye la lista completa de mensajes de error. |
| `BusinessRuleException` | `400 Bad Request` | `Business rule violation` | Logica de negocio que no pasa una regla del dominio. Por ejemplo, intentar agregar un producto con precio negativo. Se lanza manualmente desde un handler o entidad. |
| `NotFoundException` | `404 Not Found` | `Resource not found` | El recurso solicitado no existe en la base de datos. Se lanza desde un handler cuando `GetByIdAsync` retorna `null`. |
| `KeyNotFoundException` | `404 Not Found` | `Resource not found` | Alternativa al anterior cuando el recurso no se encuentra. Misma semantica que `NotFoundException`. |
| `InvalidOperationException` | `409 Conflict` | `Operation not allowed` | Operacion que no puede ejecutarse en el estado actual. Por ejemplo, intentar crear un rol que ya existe o usar un refresh token ya consumido. |
| Cualquier otra excepcion | `500 Internal Server Error` | `An unexpected error occurred` | Error inesperado. El middleware registra el error en el log con `LogError` antes de responder. El mensaje de la excepcion original no se expone al cliente. |

> `MediatorException` es una excepcion interna que lanza el mediador cuando no encuentra un handler registrado para un request. En condiciones normales no deberia ocurrir; indica un error de configuracion o que falta registrar el handler.

---

### Base.Test

Proyecto de pruebas unitarias con **MSTest**. Cubre la capa de dominio: entidades y value objects.

```
Base.Test/
└── Domain/
    ├── Entities/
    └── ValueObjects/
```

---

## Conceptos clave

| Concepto | Descripcion |
|---|---|
| Mediador propio | Despacha requests a handlers con validacion automatica previa |
| CQRS | Commands (escritura) y Queries (lectura) en casos de uso separados |
| Scrutor | Registro automatico de handlers y validadores por escaneo de ensamblado |
| Cookie HttpOnly | Los tokens JWT nunca se exponen en el body; viajan solo en cookies seguras |
| Dos DbContexts | `ApplicationDbContext` para dominio, `IdentityDbContext` para identidad |
| Unit of Work | Los commands llaman a `Commit()` explicitamente; las queries no lo necesitan |
| FluentValidation | Los validadores se asocian al request por convencion de tipos y se ejecutan automaticamente |
| Roles en claims | Los roles del usuario se incluyen en el JWT al generarlo; `[Authorize(Roles)]` los lee sin consultar la BD |
| GlobalExceptionHandler | Middleware centralizado que mapea excepciones de dominio a respuestas `ProblemDetails` uniformes |

---

## Configuracion inicial

### Prerrequisitos

- .NET 9 SDK
- SQL Server (local o remoto)

### Variables de configuracion

El proyecto lee la cadena de conexion y la configuracion JWT desde `appsettings.json`. La estructura esperada es la siguiente:

```json
{
  "ConnectionStrings": {
    "Database": "Data Source=SERVIDOR\\INSTANCIA;Initial Catalog=nombre_db;Integrated Security=True;TrustServerCertificate=True"
  },
  "EMAIL_SETTINGS": {
    "HOST": "smtp.gmail.com",
    "PORT": 587,
    "EMAIL": "correo@gmail.com",
    "PASSWORD": "xxxx xxxx xxxx xxxx"
  },
  "JwtSettings": {
    "Key": "CLAVE_SECRETA_MINIMO_32_CARACTERES",
    "Issuer": "nombre-del-proyecto",
    "Audience": "nombre-del-proyecto",
    "ExpirationMinutes": 60,
    "RefreshTokenExpirationDays": 7
  }
}
```

> Para Gmail, `PASSWORD` debe ser una contrasena de aplicacion generada desde la configuracion de seguridad de la cuenta de Google, no la contrasena normal.

### Migraciones

El proyecto tiene dos contextos de base de datos independientes. Aplica cada uno desde la **Consola del Administrador de paquetes** (Package Manager Console) en Visual Studio. Antes de ejecutar cada bloque, selecciona el proyecto correspondiente como **proyecto predeterminado** en el desplegable de la consola.

**Contexto de aplicacion** (entidades de dominio) — selecciona `Base.Infraestructure`

```powershell
Add-Migration NombreMigracion -Context ApplicationDbContext
Update-Database -Context ApplicationDbContext
```

**Contexto de identidad** (usuarios y tokens) — selecciona `Base.Identity`

```powershell
Add-Migration NombreMigracion -Context IdentityDbContext
Update-Database -Context IdentityDbContext
```

---

## Tutorial: agregar un nuevo modulo

A modo de ejemplo se muestra como agregar el modulo `Order` (Pedido) con un command de creacion y una query de listado.

### Paso 1 - Entidad en Base.Domain

Crea la entidad en `Base.Domain/Entities/`:

```csharp
// Base.Domain/Entities/Order.cs
namespace Base.Domain.Entities
{
    public class Order
    {
        public Guid Id { get; private set; }
        public Guid CustomerId { get; private set; }
        public DateTime CreatedAt { get; private set; }

        public Order(Guid customerId)
        {
            Id = Guid.CreateVersion7();
            CustomerId = customerId;
            CreatedAt = DateTime.UtcNow;
        }
    }
}
```

### Paso 2 - Configuracion de EF en Base.Infraestructure

Crea la configuracion de la entidad en `Base.Infraestructure/Configurations/`:

```csharp
// Base.Infraestructure/Configurations/OrderConfig.cs
using Base.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Base.Infraestructure.Configurations
{
    public class OrderConfig : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(o => o.Id);
            builder.Property(o => o.CustomerId).IsRequired();
            builder.Property(o => o.CreatedAt).IsRequired();
        }
    }
}
```

Agrega el `DbSet` en `ApplicationDbContext`:

```csharp
public DbSet<Order> Orders { get; set; }
```

Genera y aplica la migracion desde la Package Manager Console, con `Base.Infraestructure` seleccionado como proyecto predeterminado:

```powershell
Add-Migration NombreMigracion -Context ApplicationDbContext
Update-Database -Context ApplicationDbContext
```

### Paso 3 - Interfaz del repositorio en Base.Application

```csharp
// Base.Application/Contracts/Repositories/Orders/IOrderRepository.cs
using Base.Application.Utils.Pager;
using Base.Domain.Entities;

namespace Base.Application.Contracts.Repositories.Orders
{
    public interface IOrderRepository : IRepository<Order>
    {
        Task<IEnumerable<Order>> ListOrders(PagedQueryDto filter);
    }
}
```

### Paso 4 - DTO de respuesta en Base.Application

```csharp
// Base.Application/DTOs/Orders/OrderDetailDto.cs
namespace Base.Application.DTOs.Orders
{
    public class OrderDetailDto
    {
        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
```

### Paso 5 - Command de creacion en Base.Application

Crea la carpeta `Base.Application/UseCases/Orders/Commands/Create/` con dos archivos:

```csharp
// CreateOrderCommand.cs
using Base.Application.Utils.Mediator;

namespace Base.Application.UseCases.Orders.Commands.Create
{
    public class CreateOrderCommand : IRequest<Guid>
    {
        public required Guid CustomerId { get; set; }
    }
}
```

```csharp
// CreateOrderHandler.cs
using Base.Application.Contracts.Persistence;
using Base.Application.Contracts.Repositories.Orders;
using Base.Application.Utils.Mediator;
using Base.Domain.Entities;

namespace Base.Application.UseCases.Orders.Commands.Create
{
    public class CreateOrderHandler(IOrderRepository repository, IUnitOfWork unitOfWork)
        : IRequestHandler<CreateOrderCommand, Guid>
    {
        private readonly IOrderRepository _repository = repository;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task<Guid> Handle(CreateOrderCommand command)
        {
            var order = new Order(command.CustomerId);

            try
            {
                var result = await _repository.AddAsync(order);
                await _unitOfWork.Commit();
                return result.Id;
            }
            catch (Exception)
            {
                await _unitOfWork.Rollback();
                throw;
            }
        }
    }
}
```

### Paso 6 - Validador del command (opcional)

Si el command necesita validacion, crea el validador en `Base.Application/Validators/Orders/`. El mediador lo detectara y ejecutara automaticamente por convencion de tipos.

```csharp
// Base.Application/Validators/Orders/CreateOrderValidator.cs
using Base.Application.UseCases.Orders.Commands.Create;
using FluentValidation;

namespace Base.Application.Validators.Orders
{
    public class CreateOrderValidator : AbstractValidator<CreateOrderCommand>
    {
        public CreateOrderValidator()
        {
            RuleFor(o => o.CustomerId)
                .NotEmpty().WithMessage("El campo {PropertyName} es requerido");
        }
    }
}
```

### Paso 7 - Query de listado en Base.Application

Crea la carpeta `Base.Application/UseCases/Orders/Queries/List/`:

```csharp
// OrderListQuery.cs
using Base.Application.DTOs.Orders;
using Base.Application.Utils.Commons;
using Base.Application.Utils.Mediator;
using Base.Application.Utils.Pager;

namespace Base.Application.UseCases.Orders.Queries.List
{
    public class OrderListQuery : PagedQueryDto, IRequest<PagedResult<OrderDetailDto>>
    {
    }
}
```

```csharp
// OrderListHandler.cs
using Base.Application.Contracts.Repositories.Orders;
using Base.Application.DTOs.Orders;
using Base.Application.Utils.Commons;
using Base.Application.Utils.Mediator;

namespace Base.Application.UseCases.Orders.Queries.List
{
    public class OrderListHandler(IOrderRepository repository)
        : IRequestHandler<OrderListQuery, PagedResult<OrderDetailDto>>
    {
        private readonly IOrderRepository _repository = repository;

        public async Task<PagedResult<OrderDetailDto>> Handle(OrderListQuery request)
        {
            var orders = await _repository.ListOrders(request);
            int total = await _repository.GetTotalCount();

            var items = orders.Select(o => new OrderDetailDto
            {
                Id = o.Id,
                CustomerId = o.CustomerId,
                CreatedAt = o.CreatedAt
            }).ToList();

            return new PagedResult<OrderDetailDto>
            {
                Items = items,
                Total = total,
                Page = request.Page,
                PageSize = request.PageSize
            };
        }
    }
}
```

### Paso 8 - Repositorio en Base.Infraestructure

```csharp
// Base.Infraestructure/Repositories/Orders/OrderRepository.cs
using Base.Application.Contracts.Repositories.Orders;
using Base.Application.Utils.Pager;
using Base.Domain.Entities;
using Base.Infraestructure.Utils;
using Microsoft.EntityFrameworkCore;

namespace Base.Infraestructure.Repositories.Orders
{
    public class OrderRepository(ApplicationDbContext context)
        : BaseRepository<Order>(context), IOrderRepository
    {
        private readonly ApplicationDbContext _context = context;

        public async Task<IEnumerable<Order>> ListOrders(PagedQueryDto filter)
        {
            return await _context.Orders
                .OrderBy(o => o.CreatedAt)
                .ApplyQueryOptions(filter.Page, filter.PageSize)
                .ToListAsync();
        }
    }
}
```

Registra el repositorio en `Base.Infraestructure/DependendyInjection.cs`:

```csharp
services.AddScoped<IOrderRepository, OrderRepository>();
```

### Paso 9 - Controlador en Base.API

Crea el controlador en `Base.API/Controllers/v1/`. Usa `[Authorize]` para requerir autenticacion en todo el controlador. Si una accion debe estar restringida a un rol especifico, aplica `[Authorize(Roles = "NombreRol")]` sobre esa accion (o sobre el controlador completo si todas las acciones requieren el mismo rol).

```csharp
// Base.API/Controllers/v1/OrderController.cs
using Asp.Versioning;
using Base.Application.DTOs.Orders;
using Base.Application.UseCases.Orders.Commands.Create;
using Base.Application.UseCases.Orders.Queries.List;
using Base.Application.Utils.Commons;
using Base.Application.Utils.Mediator;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Base.Api.Controllers.v1
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    [Authorize]
    public class OrderController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;

        // Solo el Admin puede crear pedidos
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> CreateOrder(CreateOrderCommand command)
        {
            var id = await _mediator.Send(command);
            return Ok(id);
        }

        // Cualquier usuario autenticado puede listar pedidos
        [HttpGet]
        public async Task<ActionResult<PagedResult<OrderDetailDto>>> ListOrders([FromQuery] OrderListQuery query)
        {
            var result = await _mediator.Send(query);
            return Ok(result);
        }
    }
}
```

> Si el usuario no posee el rol requerido, ASP.NET retorna `403 Forbidden` automaticamente antes de llegar al mediador o al handler.

### Resumen del flujo

```
HTTP Request
    └── Controller
            └── IMediator.Send(command/query)
                    └── [FluentValidation automatica]
                            └── Handler
                                    ├── Repository  ──>  Base de datos
                                    └── IUnitOfWork.Commit()  (solo en commands)
```

Los handlers y validadores **no requieren registro manual**: Scrutor los registra automaticamente al escanear el ensamblado de `Base.Application`.
