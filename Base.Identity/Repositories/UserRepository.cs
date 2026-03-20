using Base.Application.Contracts.Repositories.Auth;
using Base.Application.DTOs.Auth;
using Base.Identity.Models;
using Microsoft.AspNetCore.Identity;

namespace Base.Identity.Repositories
{
    public class UserRepository(UserManager<User> userManager) : IUserRepository
    {
        private readonly UserManager<User> _userManager = userManager;

        public async Task<UserDetailDto> RegisterAsync(string email, string userName, string password)
        {
            var user = new User { Email = email, UserName = userName };
            var result = await _userManager.CreateAsync(user, password);

            if (!result.Succeeded)
            {
                var errors = string.Join(", ", result.Errors.Select(e => e.Description));
                throw new InvalidOperationException(errors);
            }

            return await MapToDtoAsync(user);
        }

        public async Task<UserDetailDto?> ValidateCredentialsAsync(string email, string password)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user is null) return null;

            var isValid = await _userManager.CheckPasswordAsync(user, password);
            if (!isValid) return null;

            return await MapToDtoAsync(user);
        }

        public async Task<UserDetailDto?> FindByIdAsync(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            return user is null ? null : await MapToDtoAsync(user);
        }

        public async Task<UserDetailDto?> FindByEmailAsync(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            return user is null ? null : await MapToDtoAsync(user);
        }

        public async Task<string> GeneratePasswordResetTokenAsync(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId)
                ?? throw new InvalidOperationException("Usuario no encontrado.");

            return await _userManager.GeneratePasswordResetTokenAsync(user);
        }

        public async Task ResetPasswordAsync(string userId, string token, string newPassword)
        {
            var user = await _userManager.FindByIdAsync(userId)
                ?? throw new InvalidOperationException("Usuario no encontrado.");

            var result = await _userManager.ResetPasswordAsync(user, token, newPassword);

            if (!result.Succeeded)
            {
                var errors = string.Join(", ", result.Errors.Select(e => e.Description));
                throw new InvalidOperationException(errors);
            }
        }

        public async Task AssignRoleAsync(string userId, string roleName)
        {
            var user = await _userManager.FindByIdAsync(userId)
                ?? throw new KeyNotFoundException("Usuario no encontrado.");

            var result = await _userManager.AddToRoleAsync(user, roleName);

            if (!result.Succeeded)
            {
                var errors = string.Join(", ", result.Errors.Select(e => e.Description));
                throw new InvalidOperationException(errors);
            }
        }

        public async Task RemoveRoleAsync(string userId, string roleName)
        {
            var user = await _userManager.FindByIdAsync(userId)
                ?? throw new KeyNotFoundException("Usuario no encontrado.");

            var result = await _userManager.RemoveFromRoleAsync(user, roleName);

            if (!result.Succeeded)
            {
                var errors = string.Join(", ", result.Errors.Select(e => e.Description));
                throw new InvalidOperationException(errors);
            }
        }

        public async Task<IList<string>> GetUserRolesAsync(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId)
                ?? throw new KeyNotFoundException("Usuario no encontrado.");

            return await _userManager.GetRolesAsync(user);
        }

        private async Task<UserDetailDto> MapToDtoAsync(User user)
        {
            var roles = await _userManager.GetRolesAsync(user);
            return new UserDetailDto
            {
                Id = user.Id,
                Email = user.Email ?? string.Empty,
                UserName = user.UserName ?? string.Empty,
                Roles = roles
            };
        }
    }
}
