using Microsoft.AspNetCore.Identity;

namespace Base.Domain.Entities.Auth
{
    public class ApplicationUser: IdentityUser
    {
        public bool IsDeleted { get; set; }
    }
}