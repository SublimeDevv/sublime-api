using Base.Application.Contracts.Persistence;
using Base.Application.Contracts.Repositories;
using Base.Application.Utils.Mediator;
using Base.Domain.Entities;

namespace Base.Application.UseCases.Technologies.Commands.Create
{
    public class CreateTechnologyHandler(ITechnologyRepository repository, IUnitOfWork unitOfWork) : IRequestHandler<CreateTechnologyCommand, Guid>
    {
        private readonly ITechnologyRepository _repository = repository;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task<Guid> Handle(CreateTechnologyCommand command)
        {
            var technology = new Technology(command.Name, command.Description, command.Icon, command.Color);
            await _repository.AddAsync(technology);
            await _unitOfWork.Commit();
            return technology.Id;
        }
    }
}
