using Base.Application.Utils.Mediator;

namespace Base.Application.UseCases.Posts.Commands.Update
{
    public class UpdatePostCommand : IRequest
    {
        public required Guid Id { get; set; }
        public required string Title { get; set; }
        public string? CoverImage { get; set; }
        public string? Description { get; set; }
        public string? Content { get; set; }
        public required bool IsPublic { get; set; }
        public required string Slug { get; set; }
    }
}
