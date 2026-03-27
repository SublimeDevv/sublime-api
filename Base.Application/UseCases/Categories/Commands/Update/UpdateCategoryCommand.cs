using Base.Application.Utils.Mediator;

namespace Base.Application.UseCases.Categories.Commands.Update
{
    public class UpdateCategoryCommand : IRequest
    {
        public required Guid Id { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; }
        public required string Icon { get; set; }
        public required string Color { get; set; }
    }
}
