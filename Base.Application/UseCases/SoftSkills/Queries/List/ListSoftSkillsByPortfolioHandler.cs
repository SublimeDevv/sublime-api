using Base.Application.Contracts.Repositories;
using Base.Application.DTOs.SoftSkills;
using Base.Application.Utils.Commons;
using Base.Application.Utils.Mediator;

namespace Base.Application.UseCases.SoftSkills.Queries.List
{
    public class ListSoftSkillsByPortfolioHandler(ISoftSkillRepository repository) : IRequestHandler<ListSoftSkillsByPortfolioQuery, PagedResult<SoftSkillDto>>
    {
        private readonly ISoftSkillRepository _repository = repository;

        public async Task<PagedResult<SoftSkillDto>> Handle(ListSoftSkillsByPortfolioQuery request)
        {
            var items = await _repository.ListByPortfolioAsync(request.PortfolioId, request);
            var total = await _repository.GetTotalCount();

            return new PagedResult<SoftSkillDto>
            {
                Items = items.Select(s => new SoftSkillDto
                {
                    Id = s.Id,
                    Name = s.Name,
                    Description = s.Description,
                    IsActive = s.IsActive,
                    PortfolioId = s.PortfolioId,
                    CreatedAt = s.CreatedAt,
                    UpdatedAt = s.UpdatedAt
                }).ToList(),
                Total = total,
                Page = request.Page,
                PageSize = request.PageSize
            };
        }
    }
}
