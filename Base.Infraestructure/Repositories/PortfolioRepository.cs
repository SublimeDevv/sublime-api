using Base.Application.Contracts.Repositories;
using Base.Application.Utils.Pager;
using Base.Domain.Entities;
using Base.Infraestructure.Utils;
using Microsoft.EntityFrameworkCore;

namespace Base.Infraestructure.Repositories
{
    public class PortfolioRepository(ApplicationDbContext context) : BaseRepository<Portfolio>(context), IPortfolioRepository
    {
        private readonly ApplicationDbContext _db = context;

        public async Task<IEnumerable<Portfolio>> ListAsync(PagedQueryDto filter)
        {
            return await _db.Portfolios
                .Where(p => !p.IsDeleted)
                .OrderBy(p => p.Name)
                .ApplyQueryOptions(filter.Page, filter.PageSize)
                .ToListAsync();
        }

        public async Task<Portfolio?> GetBySlugAsync(string slug)
        {
            return await _db.Portfolios
                .FirstOrDefaultAsync(p => p.Slug == slug && !p.IsDeleted);
        }
    }
}
