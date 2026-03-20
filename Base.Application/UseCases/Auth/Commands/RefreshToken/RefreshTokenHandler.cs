using Base.Application.Contracts.Repositories.Auth;
using Base.Application.DTOs.Auth;
using Base.Application.Utils.Mediator;

namespace Base.Application.UseCases.Auth.Commands.RefreshToken
{
    public class RefreshTokenHandler(
        ITokenRepository tokenRepository,
        IUserRepository userRepository) : IRequestHandler<RefreshTokenCommand, AuthTokensDto>
    {
        private readonly ITokenRepository _tokenRepository = tokenRepository;
        private readonly IUserRepository _userRepository = userRepository;

        public async Task<AuthTokensDto> Handle(RefreshTokenCommand command)
        {
            var userId = await _tokenRepository.ValidateAndConsumeRefreshTokenAsync(command.RefreshToken)
                ?? throw new UnauthorizedAccessException("Token de refresco inválido o expirado.");

            var user = await _userRepository.FindByIdAsync(userId)
                ?? throw new UnauthorizedAccessException("Usuario no encontrado.");

            var (accessToken, accessTokenExpiresAt) = _tokenRepository.GenerateAccessToken(user.Id, user.Email, user.Roles);
            var (newRefreshToken, refreshTokenExpiresAt) = await _tokenRepository.CreateRefreshTokenAsync(user.Id);

            return new AuthTokensDto
            {
                AccessToken = accessToken,
                AccessTokenExpiresAt = accessTokenExpiresAt,
                RefreshToken = newRefreshToken,
                RefreshTokenExpiresAt = refreshTokenExpiresAt
            };
        }
    }
}
