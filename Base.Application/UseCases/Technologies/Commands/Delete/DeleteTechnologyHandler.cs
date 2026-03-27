using Base.Application.Contracts.Persistence;
using Base.Application.Contracts.Repositories;
using Base.Application.Exceptions;
using Base.Application.Utils.Mediator;

namespace Base.Application.UseCases.Technologies.Commands.Delete
{
    public class DeleteTechnologyHandler(ITechnologyRepository repository, IUnitOfWork unitOfWork) : IRequestHandler<DeleteTechnologyCommand>
    {
        private readonly ITechnologyRepository _repository = repository;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task Handle(DeleteTechnologyCommand command)
        {
            var technology = await _repository.GetByIdAsync(command.Id) ?? throw new NotFoundException();
            technology.MarkAsDeleted();
            await _repository.UpdateAsync(technology);
            await _unitOfWork.Commit();
        }
    }
}
