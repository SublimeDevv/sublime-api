using Base.Application.Contracts.Repositories;
using Base.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Base.Infraestructure.Repositories
{
    public class PostCategoryRepository(ApplicationDbContext context) : BaseRepository<PostCategory>(context), IPostCategoryRepository
    {
        private readonly ApplicationDbContext _db = context;

        public async Task<IEnumerable<PostCategory>> ListByPostAsync(Guid postId)
        {
            return await _db.PostCategories
                .Where(pc => pc.PostId == postId && !pc.IsDeleted)
                .ToListAsync();
        }

        public async Task<PostCategory?> FindAsync(Guid postId, Guid categoryId)
        {
            return await _db.PostCategories
                .FirstOrDefaultAsync(pc => pc.PostId == postId && pc.CategoryId == categoryId && !pc.IsDeleted);
        }
    }
}
