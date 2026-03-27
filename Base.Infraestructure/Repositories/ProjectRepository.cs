using Base.Application.Contracts.Repositories;
using Base.Application.Utils.Pager;
using Base.Domain.Entities;
using Base.Infraestructure.Utils;
using Microsoft.EntityFrameworkCore;

namespace Base.Infraestructure.Repositories
{
    public class ProjectRepository(ApplicationDbContext context) : BaseRepository<Project>(context), IProjectRepository
    {
        private readonly ApplicationDbContext _db = context;

        public async Task<IEnumerable<Project>> ListByPortfolioAsync(Guid portfolioId, PagedQueryDto filter)
        {
            return await _db.Projects
                .Where(p => p.PortfolioId == portfolioId)
                .OrderBy(p => p.Name)
                .ApplyQueryOptions(filter.Page, filter.PageSize)
                .ToListAsync();
        }
    }
}
