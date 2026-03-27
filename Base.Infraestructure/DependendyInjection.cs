using Base.Application.Contracts.Notifications;
using Base.Application.Contracts.Persistence;
using Base.Application.Contracts.Repositories;
using Base.Infraestructure.Notifications;
using Base.Infraestructure.Repositories;
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

            services.AddScoped<ITechnologyRepository, TechnologyRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IPortfolioRepository, PortfolioRepository>();
            services.AddScoped<IPostRepository, PostRepository>();
            services.AddScoped<IProjectRepository, ProjectRepository>();
            services.AddScoped<IWorkExperienceRepository, WorkExperienceRepository>();
            services.AddScoped<ISoftSkillRepository, SoftSkillRepository>();
            services.AddScoped<ISocialMediaRepository, SocialMediaRepository>();
            services.AddScoped<IPostImageRepository, PostImageRepository>();
            services.AddScoped<IProjectImageRepository, ProjectImageRepository>();
            services.AddScoped<IPostCategoryRepository, PostCategoryRepository>();
            services.AddScoped<IPostTechnologyRepository, PostTechnologyRepository>();

            services.AddScoped<IUnitOfWork, UnitOfWorkEF>();
            services.AddScoped<IServiceNotifications, EmailService>();

            return services;
        }

    }
}