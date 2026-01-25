using Base.Application.Utils.Mediator;
using Microsoft.Extensions.DependencyInjection;

namespace Base.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {

            services.AddTransient<IMediator, Mediator>();
            services.Scan(scan => scan.FromAssembliesOf(typeof(IMediator))
            .AddClasses(c => c.AssignableTo(typeof(IRequestHandler<>)))
            .AsImplementedInterfaces()
            .WithScopedLifetime()
            .AddClasses(c => c.AssignableTo(typeof(IRequestHandler<,>)))
            .AsImplementedInterfaces()
            .WithScopedLifetime());
            
            return services;
        }   
    }
}
