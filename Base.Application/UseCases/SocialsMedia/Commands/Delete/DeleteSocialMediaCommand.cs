using Base.Application.Utils.Mediator;

namespace Base.Application.UseCases.SocialsMedia.Commands.Delete
{
    public class DeleteSocialMediaCommand : IRequest
    {
        public required Guid Id { get; set; }
    }
}
