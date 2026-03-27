using Base.Application.Utils.Mediator;

namespace Base.Application.UseCases.PostImages.Commands.Update
{
    public class UpdatePostImageCommand : IRequest
    {
        public required Guid Id { get; set; }
        public required string ImageUrl { get; set; }
        public required int Order { get; set; }
    }
}
