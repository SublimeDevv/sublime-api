using Base.Application.Contracts.Persistence;
using Base.Application.Contracts.Repositories;
using Base.Application.Exceptions;
using Base.Application.Utils.Mediator;

namespace Base.Application.UseCases.Portfolios.Commands.Update
{
    public class UpdatePortfolioHandler(IPortfolioRepository repository, IUnitOfWork unitOfWork) : IRequestHandler<UpdatePortfolioCommand>
    {
        private readonly IPortfolioRepository _repository = repository;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task Handle(UpdatePortfolioCommand command)
        {
            var portfolio = await _repository.GetByIdAsync(command.Id) ?? throw new NotFoundException();
            portfolio.Update(command.Name, command.Description, command.AboutMe, command.EmailContact, command.Phone, command.IsActive, command.Slug);
            await _repository.UpdateAsync(portfolio);
            await _unitOfWork.Commit();
        }
    }
}
