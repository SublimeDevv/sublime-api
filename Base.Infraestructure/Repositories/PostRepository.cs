using Base.Application.Contracts.Repositories;
using Base.Application.Utils.Pager;
using Base.Domain.Entities;
using Base.Infraestructure.Utils;
using Microsoft.EntityFrameworkCore;

namespace Base.Infraestructure.Repositories
{
    public class PostRepository(ApplicationDbContext context) : BaseRepository<Post>(context), IPostRepository
    {
        private readonly ApplicationDbContext _db = context;

        public async Task<IEnumerable<Post>> ListAsync(PagedQueryDto filter)
        {
            return await _db.Posts
                .Where(p => !p.IsDeleted)
                .OrderByDescending(p => p.CreatedAt)
                .ApplyQueryOptions(filter.Page, filter.PageSize)
                .ToListAsync();
        }

        public async Task<Post?> GetBySlugAsync(string slug)
        {
            return await _db.Posts
                .FirstOrDefaultAsync(p => p.Slug == slug && !p.IsDeleted);
        }
    }
}
