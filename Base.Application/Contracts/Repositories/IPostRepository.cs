using Base.Application.Utils.Pager;
using Base.Domain.Entities;

namespace Base.Application.Contracts.Repositories
{
    public interface IPostRepository : IRepository<Post>
    {
        Task<IEnumerable<Post>> ListAsync(PagedQueryDto filter);
        Task<Post?> GetBySlugAsync(string slug);
    }
}
