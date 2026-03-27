using Base.Application.Utils.Mediator;

namespace Base.Application.UseCases.PostCategories.Commands.Assign
{
    public class AssignPostCategoryCommand : IRequest<Guid>
    {
        public required Guid PostId { get; set; }
        public required Guid CategoryId { get; set; }
    }
}
