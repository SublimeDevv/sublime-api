using Base.Application.Utils.Mediator;

namespace Base.Application.UseCases.Portfolios.Commands.Update
{
    public class UpdatePortfolioCommand : IRequest
    {
        public required Guid Id { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
        public required string AboutMe { get; set; }
        public string? EmailContact { get; set; }
        public string? Phone { get; set; }
        public required bool IsActive { get; set; }
        public required string Slug { get; set; }
    }
}
