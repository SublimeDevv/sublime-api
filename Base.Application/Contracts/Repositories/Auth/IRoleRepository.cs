namespace Base.Application.Contracts.Repositories.Auth
{
    public interface IRoleRepository
    {
        Task<IList<string>> GetAllRolesAsync();
        Task CreateRoleAsync(string roleName);
        Task DeleteRoleAsync(string roleName);
        Task<bool> RoleExistsAsync(string roleName);
    }
}
