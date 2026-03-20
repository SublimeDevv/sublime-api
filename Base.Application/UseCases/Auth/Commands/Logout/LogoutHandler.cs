using Base.Application.Contracts.Repositories.Auth;
using Base.Application.Utils.Mediator;

namespace Base.Application.UseCases.Auth.Commands.Logout
{
    public class LogoutHandler(ITokenRepository tokenRepository) : IRequestHandler<LogoutCommand>
    {
        private readonly ITokenRepository _tokenRepository = tokenRepository;

        public async Task Handle(LogoutCommand command)
        {
            if (!string.IsNullOrEmpty(command.RefreshToken))
                await _tokenRepository.RevokeRefreshTokenAsync(command.RefreshToken);
        }
    }
}
