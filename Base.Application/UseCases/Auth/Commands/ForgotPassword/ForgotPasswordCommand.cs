using Base.Application.Utils.Mediator;

namespace Base.Application.UseCases.Auth.Commands.ForgotPassword
{
    public class ForgotPasswordCommand : IRequest
    {
        public required string Email { get; set; }
    }
}
