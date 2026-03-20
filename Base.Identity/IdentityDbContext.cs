using Base.Identity.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Base.Identity
{
    public class IdentityDbContext(DbContextOptions options) : IdentityDbContext<User>(options)
    {
        public DbSet<RefreshToken> RefreshToken { get; set; }
    }
}
