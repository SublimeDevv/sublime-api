using Base.Application.Contracts.Repositories;
using Base.Application.DTOs.Projects;
using Base.Application.Utils.Commons;
using Base.Application.Utils.Mediator;

namespace Base.Application.UseCases.Projects.Queries.List
{
    public class ListProjectsByPortfolioHandler(IProjectRepository repository) : IRequestHandler<ListProjectsByPortfolioQuery, PagedResult<ProjectDto>>
    {
        private readonly IProjectRepository _repository = repository;

        public async Task<PagedResult<ProjectDto>> Handle(ListProjectsByPortfolioQuery request)
        {
            var items = await _repository.ListByPortfolioAsync(request.PortfolioId, request);
            var total = await _repository.GetTotalCount();

            return new PagedResult<ProjectDto>
            {
                Items = items.Select(p => new ProjectDto
                {
                    Id = p.Id,
                    Name = p.Name,
                    Description = p.Description,
                    UrlSite = p.UrlSite,
                    UrlRepository = p.UrlRepository,
                    IsActive = p.IsActive,
                    Slug = p.Slug,
                    PortfolioId = p.PortfolioId,
                    CreatedAt = p.CreatedAt,
                    UpdatedAt = p.UpdatedAt
                }).ToList(),
                Total = total,
                Page = request.Page,
                PageSize = request.PageSize
            };
        }
    }
}
