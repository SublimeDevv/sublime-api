using Base.Application.Contracts.Persistence;
using Base.Application.Contracts.Repositories;
using Base.Application.Utils.Mediator;
using Base.Domain.Entities;

namespace Base.Application.UseCases.Posts.Commands.Create
{
    public class CreatePostHandler(IPostRepository repository, IUnitOfWork unitOfWork) : IRequestHandler<CreatePostCommand, Guid>
    {
        private readonly IPostRepository _repository = repository;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task<Guid> Handle(CreatePostCommand command)
        {
            var post = new Post(command.Title, command.CoverImage, command.Description, command.Content, command.IsPublic, command.Slug, command.UserId);
            await _repository.AddAsync(post);
            await _unitOfWork.Commit();
            return post.Id;
        }
    }
}
