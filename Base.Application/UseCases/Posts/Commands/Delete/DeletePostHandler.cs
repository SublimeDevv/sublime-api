using Base.Application.Contracts.Persistence;
using Base.Application.Contracts.Repositories;
using Base.Application.Exceptions;
using Base.Application.Utils.Mediator;

namespace Base.Application.UseCases.Posts.Commands.Delete
{
    public class DeletePostHandler(IPostRepository repository, IUnitOfWork unitOfWork) : IRequestHandler<DeletePostCommand>
    {
        private readonly IPostRepository _repository = repository;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task Handle(DeletePostCommand command)
        {
            var post = await _repository.GetByIdAsync(command.Id) ?? throw new NotFoundException();
            post.MarkAsDeleted();
            await _repository.UpdateAsync(post);
            await _unitOfWork.Commit();
        }
    }
}
