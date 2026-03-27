using Base.Application.Contracts.Repositories;
using Base.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Base.Infraestructure.Repositories
{
    public class PostImageRepository(ApplicationDbContext context) : BaseRepository<PostImage>(context), IPostImageRepository
    {
        private readonly ApplicationDbContext _db = context;

        public async Task<IEnumerable<PostImage>> ListByPostAsync(Guid postId)
        {
            return await _db.PostImages
                .Where(p => p.PostId == postId)
                .OrderBy(p => p.Order)
                .ToListAsync();
        }
    }
}
