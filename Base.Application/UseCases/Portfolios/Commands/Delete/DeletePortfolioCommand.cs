using Base.Application.Utils.Mediator;

namespace Base.Application.UseCases.Portfolios.Commands.Delete
{
    public class DeletePortfolioCommand : IRequest
    {
        public required Guid Id { get; set; }
    }
}
