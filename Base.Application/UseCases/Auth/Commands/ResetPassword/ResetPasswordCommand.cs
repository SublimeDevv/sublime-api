using Base.Application.Utils.Mediator;

namespace Base.Application.UseCases.Auth.Commands.ResetPassword
{
    public class ResetPasswordCommand : IRequest
    {
        public required string Email { get; set; }
        public required string Token { get; set; }
        public required string NewPassword { get; set; }
        public required string ConfirmPassword { get; set; }
    }
}
