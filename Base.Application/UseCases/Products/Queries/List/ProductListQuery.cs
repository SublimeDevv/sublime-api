using Base.Application.UseCases.Products.Queries.GetProduct;
using Base.Application.Utils.Commons;
using Base.Application.Utils.Mediator;
using Base.Application.Utils.Pager;

namespace Base.Application.UseCases.Products.Queries.List
{
    public class ProductListQuery: PagedQueryDto, IRequest<PagedResult<GetProductDetailDTO>>
    {
    }
}