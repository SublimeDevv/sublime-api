using Base.Application.DTOs.Auth;

namespace Base.Application.Contracts.Repositories.Auth
{
    public interface IUserRepository
    {
        Task<UserDetailDto> RegisterAsync(string email, string userName, string password);
        Task<UserDetailDto?> ValidateCredentialsAsync(string email, string password);
        Task<UserDetailDto?> FindByIdAsync(string userId);
        Task<UserDetailDto?> FindByEmailAsync(string email);
        Task<string> GeneratePasswordResetTokenAsync(string userId);
        Task ResetPasswordAsync(string userId, string token, string newPassword);
        Task AssignRoleAsync(string userId, string roleName);
        Task RemoveRoleAsync(string userId, string roleName);
        Task<IList<string>> GetUserRolesAsync(string userId);
    }
}
