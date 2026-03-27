using Base.Application.Contracts.Repositories;
using Base.Application.DTOs.SocialsMedia;
using Base.Application.Exceptions;
using Base.Application.Utils.Mediator;

namespace Base.Application.UseCases.SocialsMedia.Queries.GetById
{
    public class GetSocialMediaByIdHandler(ISocialMediaRepository repository) : IRequestHandler<GetSocialMediaByIdQuery, SocialMediaDto>
    {
        private readonly ISocialMediaRepository _repository = repository;

        public async Task<SocialMediaDto> Handle(GetSocialMediaByIdQuery request)
        {
            var socialMedia = await _repository.GetByIdAsync(request.Id) ?? throw new NotFoundException();
            return new SocialMediaDto
            {
                Id = socialMedia.Id,
                Name = socialMedia.Name,
                Icon = socialMedia.Icon,
                Color = socialMedia.Color,
                Url = socialMedia.Url,
                PortfolioId = socialMedia.PortfolioId,
                CreatedAt = socialMedia.CreatedAt,
                UpdatedAt = socialMedia.UpdatedAt
            };
        }
    }
}
