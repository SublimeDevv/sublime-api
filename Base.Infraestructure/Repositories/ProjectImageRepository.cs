using Base.Application.Contracts.Repositories;
using Base.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Base.Infraestructure.Repositories
{
    public class ProjectImageRepository(ApplicationDbContext context) : BaseRepository<ProjectImage>(context), IProjectImageRepository
    {
        private readonly ApplicationDbContext _db = context;

        public async Task<IEnumerable<ProjectImage>> ListByProjectAsync(Guid projectId)
        {
            return await _db.ProjectImages
                .Where(p => p.ProjectId == projectId && !p.IsDeleted)
                .ToListAsync();
        }
    }
}
