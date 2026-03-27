using Base.Application.Contracts.Repositories;
using Base.Application.DTOs.Posts;
using Base.Application.Utils.Commons;
using Base.Application.Utils.Mediator;

namespace Base.Application.UseCases.Posts.Queries.List
{
    public class ListPostsHandler(IPostRepository repository) : IRequestHandler<ListPostsQuery, PagedResult<PostDto>>
    {
        private readonly IPostRepository _repository = repository;

        public async Task<PagedResult<PostDto>> Handle(ListPostsQuery request)
        {
            var items = await _repository.ListAsync(request);
            var total = await _repository.GetTotalCount();

            return new PagedResult<PostDto>
            {
                Items = items.Select(p => new PostDto
                {
                    Id = p.Id,
                    Title = p.Title,
                    CoverImage = p.CoverImage,
                    Description = p.Description,
                    Content = p.Content,
                    IsPublic = p.IsPublic,
                    Slug = p.Slug,
                    UserId = p.UserId,
                    CreatedAt = p.CreatedAt,
                    UpdatedAt = p.UpdatedAt
                }).ToList(),
                Total = total,
                Page = request.Page,
                PageSize = request.PageSize
            };
        }
    }
}
