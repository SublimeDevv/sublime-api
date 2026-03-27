using Base.Application.DTOs.WorkExperiences;
using Base.Application.Utils.Commons;
using Base.Application.Utils.Mediator;
using Base.Application.Utils.Pager;

namespace Base.Application.UseCases.WorkExperiences.Queries.List
{
    public class ListWorkExperiencesByPortfolioQuery : PagedQueryDto, IRequest<PagedResult<WorkExperienceDto>>
    {
        public required Guid PortfolioId { get; set; }
    }
}
