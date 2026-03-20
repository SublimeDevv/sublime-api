using Base.Application.Contracts.Repositories.Products;
using Base.Application.DTOs.Products;
using Base.Application.Utils.Commons;
using Base.Application.Utils.Mediator;

namespace Base.Application.UseCases.Products.Queries.List
{
    public class ProductListHandler(IProductRepository repository) : IRequestHandler<ProductListQuery, PagedResult<ProductDetailDto>>
    {
        private readonly IProductRepository repository = repository;

        public async Task<PagedResult<ProductDetailDto>> Handle(ProductListQuery request)
        {

            var products = await repository.ListProducts(request);
            int total = await repository.GetTotalCount();

            var selectProducts = products.Select(p => new ProductDetailDto
            {
                Id = p.Id,
                ProductName = p.Name,
                Price = p.Price,
                ProductDescription = p.Description
            }).ToList();

            var result = new PagedResult<ProductDetailDto>
            {
                Items = selectProducts,
                Total = total,
                Page = request.Page,
                PageSize = request.PageSize
            };

            return result;

        }

    }
}
