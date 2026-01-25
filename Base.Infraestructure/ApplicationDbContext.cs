using Base.Domain.Entities;
using Base.Domain.Entities.Auth;
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

        public DbSet<Product> Products { get; set; }
        public DbSet<ApplicationUser> Users { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }

    }
}
