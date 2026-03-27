using Base.Application.Utils.Mediator;

namespace Base.Application.UseCases.Posts.Commands.Delete
{
    public class DeletePostCommand : IRequest
    {
        public required Guid Id { get; set; }
    }
}
