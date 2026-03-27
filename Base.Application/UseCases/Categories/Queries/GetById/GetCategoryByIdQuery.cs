using Base.Application.DTOs.Categories;
using Base.Application.Utils.Mediator;

namespace Base.Application.UseCases.Categories.Queries.GetById
{
    public class GetCategoryByIdQuery : IRequest<CategoryDto>
    {
        public required Guid Id { get; set; }
    }
}
