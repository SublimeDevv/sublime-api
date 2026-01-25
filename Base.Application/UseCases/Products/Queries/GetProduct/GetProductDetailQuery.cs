using Base.Application.Utils.Mediator;

namespace Base.Application.UseCases.Products.Queries.GetProduct
{
    public class GetProductDetailQuery: IRequest<GetProductDetailDTO>
    {
        public Guid Id { get; set; }
    }
}
