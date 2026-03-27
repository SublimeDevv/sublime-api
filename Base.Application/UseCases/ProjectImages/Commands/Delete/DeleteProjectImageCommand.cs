using Base.Application.Utils.Mediator;

namespace Base.Application.UseCases.ProjectImages.Commands.Delete
{
    public class DeleteProjectImageCommand : IRequest
    {
        public required Guid Id { get; set; }
    }
}
