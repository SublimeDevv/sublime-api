using Base.Application.Contracts.Repositories;
using Base.Application.DTOs.Portfolios;
using Base.Application.Exceptions;
using Base.Application.Utils.Mediator;

namespace Base.Application.UseCases.Portfolios.Queries.GetById
{
    public class GetPortfolioByIdHandler(IPortfolioRepository repository) : IRequestHandler<GetPortfolioByIdQuery, PortfolioDto>
    {
        private readonly IPortfolioRepository _repository = repository;

        public async Task<PortfolioDto> Handle(GetPortfolioByIdQuery request)
        {
            var portfolio = await _repository.GetByIdAsync(request.Id) ?? throw new NotFoundException();
            return new PortfolioDto
            {
                Id = portfolio.Id,
                Name = portfolio.Name,
                Description = portfolio.Description,
                AboutMe = portfolio.AboutMe,
                EmailContact = portfolio.EmailContact,
                Phone = portfolio.Phone,
                IsActive = portfolio.IsActive,
                Slug = portfolio.Slug,
                UserId = portfolio.UserId,
                CreatedAt = portfolio.CreatedAt,
                UpdatedAt = portfolio.UpdatedAt
            };
        }
    }
}
