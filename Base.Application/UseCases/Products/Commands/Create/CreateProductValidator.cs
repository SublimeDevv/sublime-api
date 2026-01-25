using FluentValidation;

namespace Base.Application.UseCases.Products.Commands.Create
{
    public class ValidateCreateProduct: AbstractValidator<CreateProductCommand>
    {
        public ValidateCreateProduct() {
            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("El campo {PropertyName} es requerido");
        }
    }
}
