using Base.Application.Contracts.Persistence;
using Base.Application.Contracts.Repositories;
using Base.Application.Utils.Mediator;
using Base.Domain.Entities;

namespace Base.Application.UseCases.Projects.Commands.Create
{
    public class CreateProjectHandler(IProjectRepository repository, IUnitOfWork unitOfWork) : IRequestHandler<CreateProjectCommand, Guid>
    {
        private readonly IProjectRepository _repository = repository;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task<Guid> Handle(CreateProjectCommand command)
        {
            var project = new Project(command.Name, command.Description, command.UrlSite, command.UrlRepository, command.IsActive, command.Slug, command.PortfolioId);
            await _repository.AddAsync(project);
            await _unitOfWork.Commit();
            return project.Id;
        }
    }
}
