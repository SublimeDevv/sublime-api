using Base.Application.Contracts.Persistence;
using Base.Application.Contracts.Repositories;
using Base.Application.Utils.Mediator;
using Base.Domain.Entities;

namespace Base.Application.UseCases.Categories.Commands.Create
{
    public class CreateCategoryHandler(ICategoryRepository repository, IUnitOfWork unitOfWork) : IRequestHandler<CreateCategoryCommand, Guid>
    {
        private readonly ICategoryRepository _repository = repository;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task<Guid> Handle(CreateCategoryCommand command)
        {
            var category = new Category(command.Name, command.Description, command.Icon, command.Color);
            await _repository.AddAsync(category);
            await _unitOfWork.Commit();
            return category.Id;
        }
    }
}
