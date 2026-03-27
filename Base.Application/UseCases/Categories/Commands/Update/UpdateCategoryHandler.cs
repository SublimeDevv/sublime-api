using Base.Application.Contracts.Persistence;
using Base.Application.Contracts.Repositories;
using Base.Application.Exceptions;
using Base.Application.Utils.Mediator;

namespace Base.Application.UseCases.Categories.Commands.Update
{
    public class UpdateCategoryHandler(ICategoryRepository repository, IUnitOfWork unitOfWork) : IRequestHandler<UpdateCategoryCommand>
    {
        private readonly ICategoryRepository _repository = repository;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task Handle(UpdateCategoryCommand command)
        {
            var category = await _repository.GetByIdAsync(command.Id) ?? throw new NotFoundException();
            category.Update(command.Name, command.Description, command.Icon, command.Color);
            await _repository.UpdateAsync(category);
            await _unitOfWork.Commit();
        }
    }
}
