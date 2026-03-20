using Base.Application.DTOs.Auth;
using Base.Application.Utils.Mediator;

namespace Base.Application.UseCases.Auth.Commands.RefreshToken
{
    public class RefreshTokenCommand : IRequest<AuthTokensDto>
    {
        public required string RefreshToken { get; set; }
    }
}
