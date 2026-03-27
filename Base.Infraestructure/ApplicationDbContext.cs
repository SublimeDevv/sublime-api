using Base.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Base.Infraestructure
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        protected ApplicationDbContext()
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        }

        public DbSet<Technology> Technologies { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Portfolio> Portfolios { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<WorkExperience> WorkExperiences { get; set; }
        public DbSet<SoftSkill> SoftSkills { get; set; }
        public DbSet<SocialMedia> SocialsMedia { get; set; }
        public DbSet<PostImage> PostImages { get; set; }
        public DbSet<ProjectImage> ProjectImages { get; set; }
        public DbSet<PostCategory> PostCategories { get; set; }
        public DbSet<PostTechnology> PostTechnologies { get; set; }

    }
}
