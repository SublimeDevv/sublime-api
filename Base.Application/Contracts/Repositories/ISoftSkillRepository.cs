using Base.Application.Utils.Pager;
using Base.Domain.Entities;

namespace Base.Application.Contracts.Repositories
{
    public interface ISoftSkillRepository : IRepository<SoftSkill>
    {
        Task<IEnumerable<SoftSkill>> ListByPortfolioAsync(Guid portfolioId, PagedQueryDto filter);
    }
}
