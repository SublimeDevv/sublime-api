using Base.Application.Contracts.Persistence;
using Base.Application.Contracts.Repositories;
using Base.Application.Utils.Mediator;
using Base.Domain.Entities;

namespace Base.Application.UseCases.Portfolios.Commands.Create
{
    public class CreatePortfolioHandler(IPortfolioRepository repository, IUnitOfWork unitOfWork) : IRequestHandler<CreatePortfolioCommand, Guid>
    {
        private readonly IPortfolioRepository _repository = repository;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task<Guid> Handle(CreatePortfolioCommand command)
        {
            var portfolio = new Portfolio(command.Name, command.Description, command.AboutMe, command.EmailContact, command.Phone, command.IsActive, command.Slug, command.UserId);
            await _repository.AddAsync(portfolio);
            await _unitOfWork.Commit();
            return portfolio.Id;
        }
    }
}
