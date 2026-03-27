using Base.Application.Contracts.Repositories;
using Base.Application.Utils.Pager;
using Base.Domain.Entities;
using Base.Infraestructure.Utils;
using Microsoft.EntityFrameworkCore;

namespace Base.Infraestructure.Repositories
{
    public class WorkExperienceRepository(ApplicationDbContext context) : BaseRepository<WorkExperience>(context), IWorkExperienceRepository
    {
        private readonly ApplicationDbContext _db = context;

        public async Task<IEnumerable<WorkExperience>> ListByPortfolioAsync(Guid portfolioId, PagedQueryDto filter)
        {
            return await _db.WorkExperiences
                .Where(w => w.PortfolioId == portfolioId)
                .OrderByDescending(w => w.StartDate)
                .ApplyQueryOptions(filter.Page, filter.PageSize)
                .ToListAsync();
        }
    }
}
