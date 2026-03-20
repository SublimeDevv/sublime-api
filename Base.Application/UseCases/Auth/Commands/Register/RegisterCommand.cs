using Base.Application.DTOs.Auth;
using Base.Application.Utils.Mediator;

namespace Base.Application.UseCases.Auth.Commands.Register
{
    public class RegisterCommand : IRequest<LoginResponseDto>
    {
        public required string Email { get; set; }
        public required string UserName { get; set; }
        public required string Password { get; set; }
    }
}
