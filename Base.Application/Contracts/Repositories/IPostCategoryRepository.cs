using Base.Domain.Entities;

namespace Base.Application.Contracts.Repositories
{
    public interface IPostCategoryRepository : IRepository<PostCategory>
    {
        Task<IEnumerable<PostCategory>> ListByPostAsync(Guid postId);
        Task<PostCategory?> FindAsync(Guid postId, Guid categoryId);
    }
}
