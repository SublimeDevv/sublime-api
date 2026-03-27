using Base.Application.DTOs.SocialsMedia;
using Base.Application.Utils.Mediator;

namespace Base.Application.UseCases.SocialsMedia.Queries.GetById
{
    public class GetSocialMediaByIdQuery : IRequest<SocialMediaDto>
    {
        public required Guid Id { get; set; }
    }
}
