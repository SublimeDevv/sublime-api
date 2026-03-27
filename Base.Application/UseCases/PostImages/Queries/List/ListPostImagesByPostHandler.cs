using Base.Application.Contracts.Repositories;
using Base.Application.DTOs.PostImages;
using Base.Application.Utils.Mediator;

namespace Base.Application.UseCases.PostImages.Queries.List
{
    public class ListPostImagesByPostHandler(IPostImageRepository repository) : IRequestHandler<ListPostImagesByPostQuery, List<PostImageDto>>
    {
        private readonly IPostImageRepository _repository = repository;

        public async Task<List<PostImageDto>> Handle(ListPostImagesByPostQuery request)
        {
            var items = await _repository.ListByPostAsync(request.PostId);

            return items.Select(p => new PostImageDto
            {
                Id = p.Id,
                ImageUrl = p.ImageUrl,
                Order = p.Order,
                PostId = p.PostId,
                CreatedAt = p.CreatedAt,
                UpdatedAt = p.UpdatedAt
            }).ToList();
        }
    }
}
