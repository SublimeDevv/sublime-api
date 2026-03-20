using Base.Application.UseCases.Products.Commands.Create;
using FluentValidation;

namespace Base.Application.Validators.Product
{
    public class ValidateCreateProduct: AbstractValidator<CreateProductCommand>
    {
        public ValidateCreateProduct() {
            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("El campo {PropertyName} es requerido");
        }
    }
}
