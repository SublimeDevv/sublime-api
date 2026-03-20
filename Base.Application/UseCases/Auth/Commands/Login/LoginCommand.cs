using Base.Application.DTOs.Auth;
using Base.Application.Utils.Mediator;

namespace Base.Application.UseCases.Auth.Commands.Login
{
    public class LoginCommand : IRequest<LoginResponseDto>
    {
        public required string Email { get; set; }
        public required string Password { get; set; }
    }
}
