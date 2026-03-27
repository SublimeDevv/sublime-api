using Base.Application.Utils.Pager;
using Base.Domain.Entities;

namespace Base.Application.Contracts.Repositories
{
    public interface IPortfolioRepository : IRepository<Portfolio>
    {
        Task<IEnumerable<Portfolio>> ListAsync(PagedQueryDto filter);
        Task<Portfolio?> GetBySlugAsync(string slug);
    }
}
