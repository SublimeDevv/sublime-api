using Base.Application.Contracts.Repositories;
using Base.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Base.Infraestructure.Repositories
{
    public class PostTechnologyRepository(ApplicationDbContext context) : BaseRepository<PostTechnology>(context), IPostTechnologyRepository
    {
        private readonly ApplicationDbContext _db = context;

        public async Task<IEnumerable<PostTechnology>> ListByPostAsync(Guid postId)
        {
            return await _db.PostTechnologies
                .Where(pt => pt.PostId == postId && !pt.IsDeleted)
                .ToListAsync();
        }

        public async Task<PostTechnology?> FindAsync(Guid postId, Guid technologyId)
        {
            return await _db.PostTechnologies
                .FirstOrDefaultAsync(pt => pt.PostId == postId && pt.TechnologyId == technologyId && !pt.IsDeleted);
        }
    }
}
