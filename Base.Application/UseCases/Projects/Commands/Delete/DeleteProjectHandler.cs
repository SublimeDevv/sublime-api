using Base.Application.Contracts.Persistence;
using Base.Application.Contracts.Repositories;
using Base.Application.Exceptions;
using Base.Application.Utils.Mediator;

namespace Base.Application.UseCases.Projects.Commands.Delete
{
    public class DeleteProjectHandler(IProjectRepository repository, IUnitOfWork unitOfWork) : IRequestHandler<DeleteProjectCommand>
    {
        private readonly IProjectRepository _repository = repository;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task Handle(DeleteProjectCommand command)
        {
            var project = await _repository.GetByIdAsync(command.Id) ?? throw new NotFoundException();
            project.MarkAsDeleted();
            await _repository.UpdateAsync(project);
            await _unitOfWork.Commit();
        }
    }
}
