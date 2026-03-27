using Base.Application.Contracts.Persistence;
using Base.Application.Contracts.Repositories;
using Base.Application.Utils.Mediator;
using Base.Domain.Entities;

namespace Base.Application.UseCases.PostImages.Commands.Create
{
    public class CreatePostImageHandler(IPostImageRepository repository, IUnitOfWork unitOfWork) : IRequestHandler<CreatePostImageCommand, Guid>
    {
        private readonly IPostImageRepository _repository = repository;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task<Guid> Handle(CreatePostImageCommand command)
        {
            var postImage = new PostImage(command.ImageUrl, command.Order, command.PostId);
            await _repository.AddAsync(postImage);
            await _unitOfWork.Commit();
            return postImage.Id;
        }
    }
}
