using Base.Application.Utils.Pager;
using Base.Domain.Entities;

namespace Base.Application.Contracts.Repositories
{
    public interface ITechnologyRepository : IRepository<Technology>
    {
        Task<IEnumerable<Technology>> ListAsync(PagedQueryDto filter);
    }
}
