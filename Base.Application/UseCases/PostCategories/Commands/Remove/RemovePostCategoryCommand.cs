using Base.Application.Utils.Mediator;

namespace Base.Application.UseCases.PostCategories.Commands.Remove
{
    public class RemovePostCategoryCommand : IRequest
    {
        public required Guid PostId { get; set; }
        public required Guid CategoryId { get; set; }
    }
}
