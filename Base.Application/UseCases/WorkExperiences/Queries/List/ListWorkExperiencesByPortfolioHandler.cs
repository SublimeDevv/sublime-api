using Base.Application.Contracts.Repositories;
using Base.Application.DTOs.WorkExperiences;
using Base.Application.Utils.Commons;
using Base.Application.Utils.Mediator;

namespace Base.Application.UseCases.WorkExperiences.Queries.List
{
    public class ListWorkExperiencesByPortfolioHandler(IWorkExperienceRepository repository) : IRequestHandler<ListWorkExperiencesByPortfolioQuery, PagedResult<WorkExperienceDto>>
    {
        private readonly IWorkExperienceRepository _repository = repository;

        public async Task<PagedResult<WorkExperienceDto>> Handle(ListWorkExperiencesByPortfolioQuery request)
        {
            var items = await _repository.ListByPortfolioAsync(request.PortfolioId, request);
            var total = await _repository.GetTotalCount();

            return new PagedResult<WorkExperienceDto>
            {
                Items = items.Select(w => new WorkExperienceDto
                {
                    Id = w.Id,
                    Title = w.Title,
                    Description = w.Description,
                    IsActive = w.IsActive,
                    StartDate = w.StartDate,
                    EndDate = w.EndDate,
                    PortfolioId = w.PortfolioId,
                    CreatedAt = w.CreatedAt,
                    UpdatedAt = w.UpdatedAt
                }).ToList(),
                Total = total,
                Page = request.Page,
                PageSize = request.PageSize
            };
        }
    }
}
