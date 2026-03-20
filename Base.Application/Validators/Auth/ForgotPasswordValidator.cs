using Base.Application.UseCases.Auth.Commands.ForgotPassword;
using FluentValidation;

namespace Base.Application.Validators.Auth
{
    public class ForgotPasswordValidator : AbstractValidator<ForgotPasswordCommand>
    {
        public ForgotPasswordValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("El correo electrónico es requerido.")
                .EmailAddress().WithMessage("El formato del correo electrónico no es válido.");
        }
    }
}
