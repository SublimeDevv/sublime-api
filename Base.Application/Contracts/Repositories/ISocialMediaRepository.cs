using Base.Domain.Entities;

namespace Base.Application.Contracts.Repositories
{
    public interface ISocialMediaRepository : IRepository<SocialMedia>
    {
        Task<IEnumerable<SocialMedia>> ListByPortfolioAsync(Guid portfolioId);
    }
}
