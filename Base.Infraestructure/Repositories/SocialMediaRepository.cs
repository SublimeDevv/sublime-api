using Base.Application.Contracts.Repositories;
using Base.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Base.Infraestructure.Repositories
{
    public class SocialMediaRepository(ApplicationDbContext context) : BaseRepository<SocialMedia>(context), ISocialMediaRepository
    {
        private readonly ApplicationDbContext _db = context;

        public async Task<IEnumerable<SocialMedia>> ListByPortfolioAsync(Guid portfolioId)
        {
            return await _db.SocialsMedia
                .Where(s => s.PortfolioId == portfolioId && !s.IsDeleted)
                .OrderBy(s => s.Name)
                .ToListAsync();
        }
    }
}
