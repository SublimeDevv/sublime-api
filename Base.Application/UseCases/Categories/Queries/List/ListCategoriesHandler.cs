using Base.Application.Contracts.Repositories;
using Base.Application.DTOs.Categories;
using Base.Application.Utils.Commons;
using Base.Application.Utils.Mediator;

namespace Base.Application.UseCases.Categories.Queries.List
{
    public class ListCategoriesHandler(ICategoryRepository repository) : IRequestHandler<ListCategoriesQuery, PagedResult<CategoryDto>>
    {
        private readonly ICategoryRepository _repository = repository;

        public async Task<PagedResult<CategoryDto>> Handle(ListCategoriesQuery request)
        {
            var items = await _repository.ListAsync(request);
            var total = await _repository.GetTotalCount();

            return new PagedResult<CategoryDto>
            {
                Items = items.Select(c => new CategoryDto
                {
                    Id = c.Id,
                    Name = c.Name,
                    Description = c.Description,
                    Icon = c.Icon,
                    Color = c.Color,
                    CreatedAt = c.CreatedAt,
                    UpdatedAt = c.UpdatedAt
                }).ToList(),
                Total = total,
                Page = request.Page,
                PageSize = request.PageSize
            };
        }
    }
}
