using Base.Application.Contracts.Repositories;
using Base.Application.Utils.Pager;
using Base.Domain.Entities;
using Base.Infraestructure.Utils;
using Microsoft.EntityFrameworkCore;

namespace Base.Infraestructure.Repositories
{
    public class TechnologyRepository(ApplicationDbContext context) : BaseRepository<Technology>(context), ITechnologyRepository
    {
        private readonly ApplicationDbContext _db = context;

        public async Task<IEnumerable<Technology>> ListAsync(PagedQueryDto filter)
        {
            return await _db.Technologies
                .Where(t => !t.IsDeleted)
                .OrderBy(t => t.Name)
                .ApplyQueryOptions(filter.Page, filter.PageSize)
                .ToListAsync();
        }
    }
}
