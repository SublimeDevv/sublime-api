namespace Base.Application.Contracts.Repositories.Auth
{
    public interface ITokenRepository
    {
        (string Token, DateTime ExpiresAt) GenerateAccessToken(string userId, string email, IList<string> roles);
        Task<(string Token, DateTime ExpiresAt)> CreateRefreshTokenAsync(string userId);
        Task<string?> ValidateAndConsumeRefreshTokenAsync(string refreshToken);
        Task RevokeRefreshTokenAsync(string refreshToken);
    }
}
