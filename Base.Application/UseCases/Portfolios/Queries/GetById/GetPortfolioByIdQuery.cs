using Base.Application.DTOs.Portfolios;
using Base.Application.Utils.Mediator;

namespace Base.Application.UseCases.Portfolios.Queries.GetById
{
    public class GetPortfolioByIdQuery : IRequest<PortfolioDto>
    {
        public required Guid Id { get; set; }
    }
}
