using Base.Application.Contracts.Persistence;
using Base.Application.Contracts.Repositories;
using Base.Application.Exceptions;
using Base.Application.Utils.Mediator;

namespace Base.Application.UseCases.Projects.Commands.Update
{
    public class UpdateProjectHandler(IProjectRepository repository, IUnitOfWork unitOfWork) : IRequestHandler<UpdateProjectCommand>
    {
        private readonly IProjectRepository _repository = repository;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task Handle(UpdateProjectCommand command)
        {
            var project = await _repository.GetByIdAsync(command.Id) ?? throw new NotFoundException();
            project.Update(command.Name, command.Description, command.UrlSite, command.UrlRepository, command.IsActive, command.Slug);
            await _repository.UpdateAsync(project);
            await _unitOfWork.Commit();
        }
    }
}
