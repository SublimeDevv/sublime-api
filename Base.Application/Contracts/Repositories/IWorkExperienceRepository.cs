using Base.Application.Utils.Pager;
using Base.Domain.Entities;

namespace Base.Application.Contracts.Repositories
{
    public interface IWorkExperienceRepository : IRepository<WorkExperience>
    {
        Task<IEnumerable<WorkExperience>> ListByPortfolioAsync(Guid portfolioId, PagedQueryDto filter);
    }
}
