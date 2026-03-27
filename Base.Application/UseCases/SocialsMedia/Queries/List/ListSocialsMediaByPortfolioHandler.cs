using Base.Application.Contracts.Repositories;
using Base.Application.DTOs.SocialsMedia;
using Base.Application.Utils.Mediator;

namespace Base.Application.UseCases.SocialsMedia.Queries.List
{
    public class ListSocialsMediaByPortfolioHandler(ISocialMediaRepository repository) : IRequestHandler<ListSocialsMediaByPortfolioQuery, List<SocialMediaDto>>
    {
        private readonly ISocialMediaRepository _repository = repository;

        public async Task<List<SocialMediaDto>> Handle(ListSocialsMediaByPortfolioQuery request)
        {
            var items = await _repository.ListByPortfolioAsync(request.PortfolioId);

            return items.Select(s => new SocialMediaDto
            {
                Id = s.Id,
                Name = s.Name,
                Icon = s.Icon,
                Color = s.Color,
                Url = s.Url,
                PortfolioId = s.PortfolioId,
                CreatedAt = s.CreatedAt,
                UpdatedAt = s.UpdatedAt
            }).ToList();
        }
    }
}
