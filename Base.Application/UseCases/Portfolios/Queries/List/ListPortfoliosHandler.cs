using Base.Application.Contracts.Repositories;
using Base.Application.DTOs.Portfolios;
using Base.Application.Utils.Commons;
using Base.Application.Utils.Mediator;

namespace Base.Application.UseCases.Portfolios.Queries.List
{
    public class ListPortfoliosHandler(IPortfolioRepository repository) : IRequestHandler<ListPortfoliosQuery, PagedResult<PortfolioDto>>
    {
        private readonly IPortfolioRepository _repository = repository;

        public async Task<PagedResult<PortfolioDto>> Handle(ListPortfoliosQuery request)
        {
            var items = await _repository.ListAsync(request);
            var total = await _repository.GetTotalCount();

            return new PagedResult<PortfolioDto>
            {
                Items = items.Select(p => new PortfolioDto
                {
                    Id = p.Id,
                    Name = p.Name,
                    Description = p.Description,
                    AboutMe = p.AboutMe,
                    EmailContact = p.EmailContact,
                    Phone = p.Phone,
                    IsActive = p.IsActive,
                    Slug = p.Slug,
                    UserId = p.UserId,
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
