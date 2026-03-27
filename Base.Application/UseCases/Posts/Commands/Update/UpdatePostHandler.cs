using Base.Application.Contracts.Persistence;
using Base.Application.Contracts.Repositories;
using Base.Application.Exceptions;
using Base.Application.Utils.Mediator;

namespace Base.Application.UseCases.Posts.Commands.Update
{
    public class UpdatePostHandler(IPostRepository repository, IUnitOfWork unitOfWork) : IRequestHandler<UpdatePostCommand>
    {
        private readonly IPostRepository _repository = repository;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task Handle(UpdatePostCommand command)
        {
            var post = await _repository.GetByIdAsync(command.Id) ?? throw new NotFoundException();
            post.Update(command.Title, command.CoverImage, command.Description, command.Content, command.IsPublic, command.Slug);
            await _repository.UpdateAsync(post);
            await _unitOfWork.Commit();
        }
    }
}
