using Base.Application.Contracts.Repositories.Auth;
using Base.Application.DTOs.Auth;
using Base.Application.Utils.Mediator;

namespace Base.Application.UseCases.Auth.Commands.Login
{
    public class LoginHandler(
        IUserRepository userRepository,
        ITokenRepository tokenRepository) : IRequestHandler<LoginCommand, LoginResponseDto>
    {
        private readonly IUserRepository _userRepository = userRepository;
        private readonly ITokenRepository _tokenRepository = tokenRepository;

        public async Task<LoginResponseDto> Handle(LoginCommand command)
        {
            var user = await _userRepository.ValidateCredentialsAsync(command.Email, command.Password)
                ?? throw new UnauthorizedAccessException("Credenciales inválidas.");

            var (accessToken, accessTokenExpiresAt) = _tokenRepository.GenerateAccessToken(user.Id, user.Email, user.Roles);
            var (refreshToken, refreshTokenExpiresAt) = await _tokenRepository.CreateRefreshTokenAsync(user.Id);

            return new LoginResponseDto
            {
                Tokens = new AuthTokensDto
                {
                    AccessToken = accessToken,
                    AccessTokenExpiresAt = accessTokenExpiresAt,
                    RefreshToken = refreshToken,
                    RefreshTokenExpiresAt = refreshTokenExpiresAt
                },
                User = user
            };
        }
    }
}
