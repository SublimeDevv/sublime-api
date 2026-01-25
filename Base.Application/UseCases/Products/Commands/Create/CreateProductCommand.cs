using Base.Application.Utils.Mediator;

namespace Base.Application.UseCases.Products.Commands.Create
{
    public class CreateProductCommand: IRequest<Guid>
    {
        public required string Name { get; set; }
        public required decimal Price { get; set; }
        public required string Description { get; set; } = string.Empty;

    }
}
