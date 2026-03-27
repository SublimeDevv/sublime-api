using Base.Application.DTOs.SocialsMedia;
using Base.Application.Utils.Mediator;

namespace Base.Application.UseCases.SocialsMedia.Queries.List
{
    public class ListSocialsMediaByPortfolioQuery : IRequest<List<SocialMediaDto>>
    {
        public required Guid PortfolioId { get; set; }
    }
}
