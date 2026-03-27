using Base.Application.Utils.Mediator;

namespace Base.Application.UseCases.Categories.Commands.Delete
{
    public class DeleteCategoryCommand : IRequest
    {
        public required Guid Id { get; set; }
    }
}
