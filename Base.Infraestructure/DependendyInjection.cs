using Base.Application.Contracts.Notifications;
using Base.Application.Contracts.Persistence;
using Base.Application.Contracts.Repositories.Auth;
using Base.Application.Contracts.Repositories.Products;
using Base.Infraestructure.Notifications;
using Base.Infraestructure.Repositories.Products;
using Base.Infraestructure.UnitsOfWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Base.Infraestructure
{
    public static class DependendyInjection
    {
        public static IServiceCollection AddInfraestructure(this IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer("name=Database"));
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWorkEF>();
            services.AddScoped<IServiceNotifications, EmailService>();

            return services;
        }

    }
}