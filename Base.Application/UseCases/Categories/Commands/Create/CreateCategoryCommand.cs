using Base.Application.Utils.Mediator;

namespace Base.Application.UseCases.Categories.Commands.Create
{
    public class CreateCategoryCommand : IRequest<Guid>
    {
        public required string Name { get; set; }
        public string? Description { get; set; }
        public required string Icon { get; set; }
        public required string Color { get; set; }
    }
}
