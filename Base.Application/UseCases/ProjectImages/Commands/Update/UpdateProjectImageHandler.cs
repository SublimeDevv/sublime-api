using Base.Application.Contracts.Persistence;
using Base.Application.Contracts.Repositories;
using Base.Application.Exceptions;
using Base.Application.Utils.Mediator;

namespace Base.Application.UseCases.ProjectImages.Commands.Update
{
    public class UpdateProjectImageHandler(IProjectImageRepository repository, IUnitOfWork unitOfWork) : IRequestHandler<UpdateProjectImageCommand>
    {
        private readonly IProjectImageRepository _repository = repository;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task Handle(UpdateProjectImageCommand command)
        {
            var projectImage = await _repository.GetByIdAsync(command.Id) ?? throw new NotFoundException();
            projectImage.Update(command.UrlImage);
            await _repository.UpdateAsync(projectImage);
            await _unitOfWork.Commit();
        }
    }
}
