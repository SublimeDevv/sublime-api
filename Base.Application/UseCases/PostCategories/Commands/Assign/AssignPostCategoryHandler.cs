using Base.Application.Contracts.Persistence;
using Base.Application.Contracts.Repositories;
using Base.Application.Exceptions;
using Base.Application.Utils.Mediator;
using Base.Domain.Entities;

namespace Base.Application.UseCases.PostCategories.Commands.Assign
{
    public class AssignPostCategoryHandler(IPostCategoryRepository repository, IUnitOfWork unitOfWork) : IRequestHandler<AssignPostCategoryCommand, Guid>
    {
        private readonly IPostCategoryRepository _repository = repository;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task<Guid> Handle(AssignPostCategoryCommand command)
        {
            var existing = await _repository.FindAsync(command.PostId, command.CategoryId);
            if (existing is not null)
                throw new BusinessRuleException("Category is already assigned to this post.");

            var postCategory = new PostCategory(command.PostId, command.CategoryId);
            await _repository.AddAsync(postCategory);
            await _unitOfWork.Commit();
            return postCategory.Id;
        }
    }
}
