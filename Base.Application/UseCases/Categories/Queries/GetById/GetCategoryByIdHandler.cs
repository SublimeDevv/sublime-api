using Base.Application.Contracts.Repositories;
using Base.Application.DTOs.Categories;
using Base.Application.Exceptions;
using Base.Application.Utils.Mediator;

namespace Base.Application.UseCases.Categories.Queries.GetById
{
    public class GetCategoryByIdHandler(ICategoryRepository repository) : IRequestHandler<GetCategoryByIdQuery, CategoryDto>
    {
        private readonly ICategoryRepository _repository = repository;

        public async Task<CategoryDto> Handle(GetCategoryByIdQuery request)
        {
            var category = await _repository.GetByIdAsync(request.Id) ?? throw new NotFoundException();
            return new CategoryDto
            {
                Id = category.Id,
                Name = category.Name,
                Description = category.Description,
                Icon = category.Icon,
                Color = category.Color,
                CreatedAt = category.CreatedAt,
                UpdatedAt = category.UpdatedAt
            };
        }
    }
}
