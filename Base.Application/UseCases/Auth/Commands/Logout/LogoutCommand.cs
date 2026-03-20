using Base.Application.Utils.Mediator;

namespace Base.Application.UseCases.Auth.Commands.Logout
{
    public class LogoutCommand : IRequest
    {
        public string? RefreshToken { get; set; }
    }
}
