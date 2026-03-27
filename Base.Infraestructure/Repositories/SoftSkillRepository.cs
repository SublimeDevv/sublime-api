using Base.Application.Contracts.Repositories;
using Base.Application.Utils.Pager;
using Base.Domain.Entities;
using Base.Infraestructure.Utils;
using Microsoft.EntityFrameworkCore;

namespace Base.Infraestructure.Repositories
{
    public class SoftSkillRepository(ApplicationDbContext context) : BaseRepository<SoftSkill>(context), ISoftSkillRepository
    {
        private readonly ApplicationDbContext _db = context;

        public async Task<IEnumerable<SoftSkill>> ListByPortfolioAsync(Guid portfolioId, PagedQueryDto filter)
        {
            return await _db.SoftSkills
                .Where(s => s.PortfolioId == portfolioId)
                .OrderBy(s => s.Name)
                .ApplyQueryOptions(filter.Page, filter.PageSize)
                .ToListAsync();
        }
    }
}
