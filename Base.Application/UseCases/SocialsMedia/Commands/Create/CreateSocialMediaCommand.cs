using Base.Application.Utils.Mediator;

namespace Base.Application.UseCases.SocialsMedia.Commands.Create
{
    public class CreateSocialMediaCommand : IRequest<Guid>
    {
        public required string Name { get; set; }
        public required string Icon { get; set; }
        public required string Color { get; set; }
        public required string Url { get; set; }
        public required Guid PortfolioId { get; set; }
    }
}
