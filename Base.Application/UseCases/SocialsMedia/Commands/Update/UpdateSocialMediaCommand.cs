using Base.Application.Utils.Mediator;

namespace Base.Application.UseCases.SocialsMedia.Commands.Update
{
    public class UpdateSocialMediaCommand : IRequest
    {
        public required Guid Id { get; set; }
        public required string Name { get; set; }
        public required string Icon { get; set; }
        public required string Color { get; set; }
        public required string Url { get; set; }
    }
}
