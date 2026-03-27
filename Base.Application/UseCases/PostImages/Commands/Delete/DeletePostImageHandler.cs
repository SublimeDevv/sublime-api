using Base.Application.Contracts.Persistence;
using Base.Application.Contracts.Repositories;
using Base.Application.Exceptions;
using Base.Application.Utils.Mediator;

namespace Base.Application.UseCases.PostImages.Commands.Delete
{
    public class DeletePostImageHandler(IPostImageRepository repository, IUnitOfWork unitOfWork) : IRequestHandler<DeletePostImageCommand>
    {
        private readonly IPostImageRepository _repository = repository;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task Handle(DeletePostImageCommand command)
        {
            var postImage = await _repository.GetByIdAsync(command.Id) ?? throw new NotFoundException();
            postImage.MarkAsDeleted();
            await _repository.UpdateAsync(postImage);
            await _unitOfWork.Commit();
        }
    }
}
