using Base.Application.Contracts.Notifications;
using Base.Application.Contracts.Repositories.Products;
using Base.Application.UseCases.Products.Queries.GetProduct;
using Base.Application.Utils.Commons;
using Base.Application.Utils.Mediator;
using Base.Application.Utils.Result;

namespace Base.Application.UseCases.Products.Queries.List
{
    public class ProductListHandler(IProductRepository repository, IServiceNotifications notification) : IRequestHandler<ProductListQuery, PagedResult<GetProductDetailDTO>>
    {
        private readonly IProductRepository repository = repository;
        private readonly IServiceNotifications notification = notification;

        public async Task<Result<PagedResult<GetProductDetailDTO>>> Handle(ProductListQuery request)
        {

            var products = await repository.ListProducts(request);
            int total = await repository.GetTotalCount();

            var selectProducts = products.Select(p => new GetProductDetailDTO
            {
                Id = p.Id,
                ProductName = p.Name,
                Price = p.Price,
                ProductDescription = p.Description
            }).ToList();

            var result = new PagedResult<GetProductDetailDTO>
            {
                Items = selectProducts,
                Total = total
            };

            await notification.SendEmail();

            return Result.Success(result, "Listado correcto.");

        }

    }
}
