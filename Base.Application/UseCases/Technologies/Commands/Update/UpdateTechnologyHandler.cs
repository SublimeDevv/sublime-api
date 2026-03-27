using Base.Application.Contracts.Persistence;
using Base.Application.Contracts.Repositories;
using Base.Application.Exceptions;
using Base.Application.Utils.Mediator;

namespace Base.Application.UseCases.Technologies.Commands.Update
{
    public class UpdateTechnologyHandler(ITechnologyRepository repository, IUnitOfWork unitOfWork) : IRequestHandler<UpdateTechnologyCommand>
    {
        private readonly ITechnologyRepository _repository = repository;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task Handle(UpdateTechnologyCommand command)
        {
            var technology = await _repository.GetByIdAsync(command.Id) ?? throw new NotFoundException();
            technology.Update(command.Name, command.Description, command.Icon, command.Color);
            await _repository.UpdateAsync(technology);
            await _unitOfWork.Commit();
        }
    }
}
