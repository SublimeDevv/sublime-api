using Base.Application.Utils.Pager;
using Base.Domain.Entities;

namespace Base.Application.Contracts.Repositories.Products
{
    public interface IProductRepository: IRepository<Product>
    {
        Task<IEnumerable<Product>> ListProducts(PagedQueryDto filter);
    }
}
