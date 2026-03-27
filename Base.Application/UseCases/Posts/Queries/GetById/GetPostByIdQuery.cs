using Base.Application.DTOs.Posts;
using Base.Application.Utils.Mediator;

namespace Base.Application.UseCases.Posts.Queries.GetById
{
    public class GetPostByIdQuery : IRequest<PostDto>
    {
        public required Guid Id { get; set; }
    }
}
