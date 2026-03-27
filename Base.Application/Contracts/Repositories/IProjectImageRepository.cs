using Base.Domain.Entities;

namespace Base.Application.Contracts.Repositories
{
    public interface IProjectImageRepository : IRepository<ProjectImage>
    {
        Task<IEnumerable<ProjectImage>> ListByProjectAsync(Guid projectId);
    }
}
