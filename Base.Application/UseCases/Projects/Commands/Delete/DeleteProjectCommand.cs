using Base.Application.Utils.Mediator;

namespace Base.Application.UseCases.Projects.Commands.Delete
{
    public class DeleteProjectCommand : IRequest
    {
        public required Guid Id { get; set; }
    }
}
