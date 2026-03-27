using Base.Application.DTOs.Technologies;
using Base.Application.Utils.Commons;
using Base.Application.Utils.Mediator;
using Base.Application.Utils.Pager;

namespace Base.Application.UseCases.Technologies.Queries.List
{
    public class ListTechnologiesQuery : PagedQueryDto, IRequest<PagedResult<TechnologyDto>>
    {
    }
}
