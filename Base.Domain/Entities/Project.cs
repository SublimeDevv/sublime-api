using System.ComponentModel.DataAnnotations.Schema;

namespace Base.Domain.Entities
{
    public class Project : BaseEntity
    {
        public string Name { get; private set; } = null!;
        public string? Description { get; private set; }
        public string? UrlSite { get; private set; }
        public string? UrlRepository { get; private set; }
        public bool IsActive { get; private set; }
        public string Slug { get; private set; } = null!;
        public Guid PortfolioId { get; private set; }

        public Project(string name, string? description, string? urlSite, string? urlRepository, bool isActive, string slug, Guid portfolioId)
        {
            Name = name;
            Description = description;
            UrlSite = urlSite;
            UrlRepository = urlRepository;
            IsActive = isActive;
            Slug = slug;
            PortfolioId = portfolioId;
        }

        public void Update(string name, string? description, string? urlSite, string? urlRepository, bool isActive, string slug)
        {
            Name = name;
            Description = description;
            UrlSite = urlSite;
            UrlRepository = urlRepository;
            IsActive = isActive;
            Slug = slug;
            SetUpdated();
        }
    }
}
