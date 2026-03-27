using Base.Application.Contracts.Repositories;
using Base.Application.Utils.Pager;
using Base.Domain.Entities;
using Base.Infraestructure.Utils;
using Microsoft.EntityFrameworkCore;

namespace Base.Infraestructure.Repositories
{
    public class CategoryRepository(ApplicationDbContext context) : BaseRepository<Category>(context), ICategoryRepository
    {
        private readonly ApplicationDbContext _db = context;

        public async Task<IEnumerable<Category>> ListAsync(PagedQueryDto filter)
        {
            return await _db.Categories
                .Where(c => !c.IsDeleted)
                .OrderBy(c => c.Name)
                .ApplyQueryOptions(filter.Page, filter.PageSize)
                .ToListAsync();
        }
    }
}
