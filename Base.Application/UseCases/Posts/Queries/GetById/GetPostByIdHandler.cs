using Base.Application.Contracts.Repositories;
using Base.Application.DTOs.Posts;
using Base.Application.Exceptions;
using Base.Application.Utils.Mediator;

namespace Base.Application.UseCases.Posts.Queries.GetById
{
    public class GetPostByIdHandler(IPostRepository repository) : IRequestHandler<GetPostByIdQuery, PostDto>
    {
        private readonly IPostRepository _repository = repository;

        public async Task<PostDto> Handle(GetPostByIdQuery request)
        {
            var post = await _repository.GetByIdAsync(request.Id) ?? throw new NotFoundException();
            return new PostDto
            {
                Id = post.Id,
                Title = post.Title,
                CoverImage = post.CoverImage,
                Description = post.Description,
                Content = post.Content,
                IsPublic = post.IsPublic,
                Slug = post.Slug,
                UserId = post.UserId,
                CreatedAt = post.CreatedAt,
                UpdatedAt = post.UpdatedAt
            };
        }
    }
}
