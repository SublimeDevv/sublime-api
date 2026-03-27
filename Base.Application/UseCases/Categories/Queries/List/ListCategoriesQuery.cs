using Base.Application.DTOs.Categories;
using Base.Application.Utils.Commons;
using Base.Application.Utils.Mediator;
using Base.Application.Utils.Pager;

namespace Base.Application.UseCases.Categories.Queries.List
{
    public class ListCategoriesQuery : PagedQueryDto, IRequest<PagedResult<CategoryDto>>
    {
    }
}
