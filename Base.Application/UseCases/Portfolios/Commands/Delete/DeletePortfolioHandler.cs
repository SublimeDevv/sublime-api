using Base.Application.Contracts.Persistence;
using Base.Application.Contracts.Repositories;
using Base.Application.Exceptions;
using Base.Application.Utils.Mediator;

namespace Base.Application.UseCases.Portfolios.Commands.Delete
{
    public class DeletePortfolioHandler(IPortfolioRepository repository, IUnitOfWork unitOfWork) : IRequestHandler<DeletePortfolioCommand>
    {
        private readonly IPortfolioRepository _repository = repository;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task Handle(DeletePortfolioCommand command)
        {
            var portfolio = await _repository.GetByIdAsync(command.Id) ?? throw new NotFoundException();
            portfolio.MarkAsDeleted();
            await _repository.UpdateAsync(portfolio);
            await _unitOfWork.Commit();
        }
    }
}
