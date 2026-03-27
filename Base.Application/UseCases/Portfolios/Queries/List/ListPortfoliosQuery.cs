using Base.Application.DTOs.Portfolios;
using Base.Application.Utils.Commons;
using Base.Application.Utils.Mediator;
using Base.Application.Utils.Pager;

namespace Base.Application.UseCases.Portfolios.Queries.List
{
    public class ListPortfoliosQuery : PagedQueryDto, IRequest<PagedResult<PortfolioDto>>
    {
    }
}
