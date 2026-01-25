using Base.Application.Contracts.Repositories.Products;
using Base.Application.Exceptions;
using Base.Application.Utils.Mediator;
using Base.Application.Utils.Result;

namespace Base.Application.UseCases.Products.Queries.GetProduct
{
    public class GetProductDetailHandler(IProductRepository repository) : IRequestHandler<GetProductDetailQuery, GetProductDetailDTO>
    {
        private readonly IProductRepository repository = repository;

        public async Task<Result<GetProductDetailDTO>> Handle(GetProductDetailQuery request)
        {

            var findProduct = await repository.GetByIdAsync(request.Id);

            if (findProduct is null)
            {
                throw new NotFoundException();
            }

            var product = new GetProductDetailDTO
            {
                Id = request.Id,
                ProductName = "Sample Product",
                Price = 99.99m,
                ProductDescription = "This is a sample product description."
            };

            return Result.Success(product);
        }
    }
}
