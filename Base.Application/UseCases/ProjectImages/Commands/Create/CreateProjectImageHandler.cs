using Base.Application.Contracts.Persistence;
using Base.Application.Contracts.Repositories;
using Base.Application.Utils.Mediator;
using Base.Domain.Entities;

namespace Base.Application.UseCases.ProjectImages.Commands.Create
{
    public class CreateProjectImageHandler(IProjectImageRepository repository, IUnitOfWork unitOfWork) : IRequestHandler<CreateProjectImageCommand, Guid>
    {
        private readonly IProjectImageRepository _repository = repository;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task<Guid> Handle(CreateProjectImageCommand command)
        {
            var projectImage = new ProjectImage(command.UrlImage, command.ProjectId);
            await _repository.AddAsync(projectImage);
            await _unitOfWork.Commit();
            return projectImage.Id;
        }
    }
}
