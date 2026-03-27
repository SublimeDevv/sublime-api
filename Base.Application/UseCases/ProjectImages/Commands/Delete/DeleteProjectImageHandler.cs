using Base.Application.Contracts.Persistence;
using Base.Application.Contracts.Repositories;
using Base.Application.Exceptions;
using Base.Application.Utils.Mediator;

namespace Base.Application.UseCases.ProjectImages.Commands.Delete
{
    public class DeleteProjectImageHandler(IProjectImageRepository repository, IUnitOfWork unitOfWork) : IRequestHandler<DeleteProjectImageCommand>
    {
        private readonly IProjectImageRepository _repository = repository;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task Handle(DeleteProjectImageCommand command)
        {
            var projectImage = await _repository.GetByIdAsync(command.Id) ?? throw new NotFoundException();
            projectImage.MarkAsDeleted();
            await _repository.UpdateAsync(projectImage);
            await _unitOfWork.Commit();
        }
    }
}
