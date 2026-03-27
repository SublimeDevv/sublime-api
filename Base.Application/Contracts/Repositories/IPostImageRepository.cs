using Base.Domain.Entities;

namespace Base.Application.Contracts.Repositories
{
    public interface IPostImageRepository : IRepository<PostImage>
    {
        Task<IEnumerable<PostImage>> ListByPostAsync(Guid postId);
    }
}
