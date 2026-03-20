using Base.Application.Contracts.Repositories.Auth;
using Base.Application.DTOs.Auth;
using Base.Application.Utils.Mediator;

namespace Base.Application.UseCases.Auth.Commands.Register
{
    public class RegisterHandler(
        IUserRepository userRepository,
        ITokenRepository tokenRepository) : IRequestHandler<RegisterCommand, LoginResponseDto>
    {
        private readonly IUserRepository _userRepository = userRepository;
        private readonly ITokenRepository _tokenRepository = tokenRepository;

        public async Task<LoginResponseDto> Handle(RegisterCommand command)
        {
            var user = await _userRepository.RegisterAsync(command.Email, command.UserName, command.Password);

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
