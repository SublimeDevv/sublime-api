using Base.Application.Contracts.Persistence;
using Base.Application.Contracts.Repositories;
using Base.Application.Exceptions;
using Base.Application.Utils.Mediator;

namespace Base.Application.UseCases.PostImages.Commands.Update
{
    public class UpdatePostImageHandler(IPostImageRepository repository, IUnitOfWork unitOfWork) : IRequestHandler<UpdatePostImageCommand>
    {
        private readonly IPostImageRepository _repository = repository;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task Handle(UpdatePostImageCommand command)
        {
            var postImage = await _repository.GetByIdAsync(command.Id) ?? throw new NotFoundException();
            postImage.Update(command.ImageUrl, command.Order);
            await _repository.UpdateAsync(postImage);
            await _unitOfWork.Commit();
        }
    }
}
