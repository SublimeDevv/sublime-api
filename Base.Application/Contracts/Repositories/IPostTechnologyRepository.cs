using Base.Domain.Entities;

namespace Base.Application.Contracts.Repositories
{
    public interface IPostTechnologyRepository : IRepository<PostTechnology>
    {
        Task<IEnumerable<PostTechnology>> ListByPostAsync(Guid postId);
        Task<PostTechnology?> FindAsync(Guid postId, Guid technologyId);
    }
}
