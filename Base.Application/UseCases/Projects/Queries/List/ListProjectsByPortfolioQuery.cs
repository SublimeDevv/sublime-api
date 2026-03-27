using Base.Application.DTOs.Projects;
using Base.Application.Utils.Commons;
using Base.Application.Utils.Mediator;
using Base.Application.Utils.Pager;

namespace Base.Application.UseCases.Projects.Queries.List
{
    public class ListProjectsByPortfolioQuery : PagedQueryDto, IRequest<PagedResult<ProjectDto>>
    {
        public required Guid PortfolioId { get; set; }
    }
}
