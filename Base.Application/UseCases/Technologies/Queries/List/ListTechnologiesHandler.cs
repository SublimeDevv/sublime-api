using Base.Application.Contracts.Repositories;
using Base.Application.DTOs.Technologies;
using Base.Application.Utils.Commons;
using Base.Application.Utils.Mediator;

namespace Base.Application.UseCases.Technologies.Queries.List
{
    public class ListTechnologiesHandler(ITechnologyRepository repository) : IRequestHandler<ListTechnologiesQuery, PagedResult<TechnologyDto>>
    {
        private readonly ITechnologyRepository _repository = repository;

        public async Task<PagedResult<TechnologyDto>> Handle(ListTechnologiesQuery request)
        {
            var items = await _repository.ListAsync(request);
            var total = await _repository.GetTotalCount();

            return new PagedResult<TechnologyDto>
            {
                Items = items.Select(t => new TechnologyDto
                {
                    Id = t.Id,
                    Name = t.Name,
                    Description = t.Description,
                    Icon = t.Icon,
                    Color = t.Color,
                    CreatedAt = t.CreatedAt,
                    UpdatedAt = t.UpdatedAt
                }).ToList(),
                Total = total,
                Page = request.Page,
                PageSize = request.PageSize
            };
        }
    }
}
