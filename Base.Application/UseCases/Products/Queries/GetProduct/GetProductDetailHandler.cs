using Base.Application.Contracts.Repositories.Products;
using Base.Application.DTOs.Products;
using Base.Application.Exceptions;
using Base.Application.Utils.Mediator;

namespace Base.Application.UseCases.Products.Queries.GetProduct
{
    public class GetProductDetailHandler(IProductRepository repository) : IRequestHandler<GetProductDetailQuery, ProductDetailDto>
    {
        private readonly IProductRepository repository = repository;

        public async Task<ProductDetailDto> Handle(GetProductDetailQuery request)
        {
            var findProduct = await repository.GetByIdAsync(request.Id) ?? throw new NotFoundException();

            var product = new ProductDetailDto
            {
                Id = request.Id,
                ProductName = findProduct.Name,
                Price = findProduct.Price,
                ProductDescription = findProduct.Description
            };

            return product;
        }
    }
}
