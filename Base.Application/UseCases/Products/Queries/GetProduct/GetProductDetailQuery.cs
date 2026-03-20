using Base.Application.DTOs.Products;
using Base.Application.Utils.Mediator;

namespace Base.Application.UseCases.Products.Queries.GetProduct
{
    public class GetProductDetailQuery: IRequest<ProductDetailDto>
    {
        public Guid Id { get; set; }
    }
}
