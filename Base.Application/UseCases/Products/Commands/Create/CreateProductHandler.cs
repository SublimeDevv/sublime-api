using Base.Application.Contracts.Persistence;
using Base.Application.Contracts.Repositories.Products;
using Base.Application.Utils.Mediator;
using Base.Application.Utils.Result;
using Base.Domain.Entities;

namespace Base.Application.UseCases.Products.Commands.Create
{
    public class CreateProductHandler(IProductRepository repositorio, IUnitOfWork unitOfWork): IRequestHandler<CreateProductCommand, Guid>
    {
        private readonly IProductRepository repository = repositorio;
        private readonly IUnitOfWork unitOfWork = unitOfWork;

        public async Task<Result<Guid>> Handle(CreateProductCommand command)
        {
            var product = new Product(command.Name, command.Price, command.Description);

            try
            {
                var result = await repository.AddAsync(product);
                await unitOfWork.Commit();
                return Result.Success(result.Id);
            } catch (Exception)
            {
                await unitOfWork.Rollback();
                throw;
            }
        }
    }
}