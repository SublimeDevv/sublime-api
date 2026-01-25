using Base.Application.Contracts.Repositories.Products;
using Base.Application.Utils.Pager;
using Base.Domain.Entities;
using Base.Infraestructure.Utils;
using Microsoft.EntityFrameworkCore;

namespace Base.Infraestructure.Repositories.Products
{
    public class ProductRepository(ApplicationDbContext context) : BaseRepository<Product>(context), IProductRepository
    {
        private readonly ApplicationDbContext context = context;

        public async Task<IEnumerable<Product>> ListProducts(PagedQueryDto filter)
        {
            return await context.Products.OrderBy(x => x.Id).ApplyQueryOptions(filter.Page, filter.Size).ToListAsync();
        }
    }
}