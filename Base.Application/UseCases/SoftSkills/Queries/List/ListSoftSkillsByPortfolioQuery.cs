using Base.Application.DTOs.SoftSkills;
using Base.Application.Utils.Commons;
using Base.Application.Utils.Mediator;
using Base.Application.Utils.Pager;

namespace Base.Application.UseCases.SoftSkills.Queries.List
{
    public class ListSoftSkillsByPortfolioQuery : PagedQueryDto, IRequest<PagedResult<SoftSkillDto>>
    {
        public required Guid PortfolioId { get; set; }
    }
}
