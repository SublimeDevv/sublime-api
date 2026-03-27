using Base.Application.Utils.Mediator;

namespace Base.Application.UseCases.Portfolios.Commands.Create
{
    public class CreatePortfolioCommand : IRequest<Guid>
    {
        public required string Name { get; set; }
        public required string Description { get; set; }
        public required string AboutMe { get; set; }
        public string? EmailContact { get; set; }
        public string? Phone { get; set; }
        public required bool IsActive { get; set; }
        public required string Slug { get; set; }
        public required string UserId { get; set; }
    }
}
