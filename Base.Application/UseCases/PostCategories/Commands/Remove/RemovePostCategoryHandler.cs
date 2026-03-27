using Base.Application.Contracts.Persistence;
using Base.Application.Contracts.Repositories;
using Base.Application.Exceptions;
using Base.Application.Utils.Mediator;

namespace Base.Application.UseCases.PostCategories.Commands.Remove
{
    public class RemovePostCategoryHandler(IPostCategoryRepository repository, IUnitOfWork unitOfWork) : IRequestHandler<RemovePostCategoryCommand>
    {
        private readonly IPostCategoryRepository _repository = repository;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task Handle(RemovePostCategoryCommand command)
        {
            var postCategory = await _repository.FindAsync(command.PostId, command.CategoryId) ?? throw new NotFoundException();
            postCategory.MarkAsDeleted();
            await _repository.UpdateAsync(postCategory);
            await _unitOfWork.Commit();
        }
    }
}
