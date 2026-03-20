using Base.Application.Contracts.Repositories.Auth;
using Base.Application.Exceptions;
using Microsoft.AspNetCore.Identity;

namespace Base.Identity.Repositories
{
    public class RoleRepository(RoleManager<IdentityRole> roleManager) : IRoleRepository
    {
        private readonly RoleManager<IdentityRole> _roleManager = roleManager;

        public Task<IList<string>> GetAllRolesAsync()
        {
            IList<string> roles = _roleManager.Roles.Select(r => r.Name!).ToList();
            return Task.FromResult(roles);
        }

        public async Task CreateRoleAsync(string roleName)
        {
            if (await _roleManager.RoleExistsAsync(roleName))
                throw new InvalidOperationException($"El rol '{roleName}' ya existe.");

            var result = await _roleManager.CreateAsync(new IdentityRole(roleName));

            if (!result.Succeeded)
            {
                var errors = string.Join(", ", result.Errors.Select(e => e.Description));
                throw new InvalidOperationException(errors);
            }
        }

        public async Task DeleteRoleAsync(string roleName)
        {
            var role = await _roleManager.FindByNameAsync(roleName)
                ?? throw new BusinessRuleException($"El rol '{roleName}' no existe.");

            var result = await _roleManager.DeleteAsync(role);

            if (!result.Succeeded)
            {
                var errors = string.Join(", ", result.Errors.Select(e => e.Description));
                throw new InvalidOperationException(errors);
            }
        }

        public Task<bool> RoleExistsAsync(string roleName) =>
            _roleManager.RoleExistsAsync(roleName);
    }
}
