using Base.Application.Utils.Mediator;

namespace Base.Application.UseCases.PostImages.Commands.Create
{
    public class CreatePostImageCommand : IRequest<Guid>
    {
        public required string ImageUrl { get; set; }
        public required int Order { get; set; }
        public required Guid PostId { get; set; }
    }
}
