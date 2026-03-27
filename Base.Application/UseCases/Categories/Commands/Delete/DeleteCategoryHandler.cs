using Base.Application.Contracts.Persistence;
using Base.Application.Contracts.Repositories;
using Base.Application.Exceptions;
using Base.Application.Utils.Mediator;

namespace Base.Application.UseCases.Categories.Commands.Delete
{
    public class DeleteCategoryHandler(ICategoryRepository repository, IUnitOfWork unitOfWork) : IRequestHandler<DeleteCategoryCommand>
    {
        private readonly ICategoryRepository _repository = repository;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task Handle(DeleteCategoryCommand command)
        {
            var category = await _repository.GetByIdAsync(command.Id) ?? throw new NotFoundException();
            category.MarkAsDeleted();
            await _repository.UpdateAsync(category);
            await _unitOfWork.Commit();
        }
    }
}
