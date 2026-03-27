using Base.Application.Utils.Mediator;

namespace Base.Application.UseCases.PostImages.Commands.Delete
{
    public class DeletePostImageCommand : IRequest
    {
        public required Guid Id { get; set; }
    }
}
