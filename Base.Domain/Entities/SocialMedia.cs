using System.ComponentModel.DataAnnotations.Schema;

namespace Base.Domain.Entities
{
    public class SocialMedia : BaseEntity
    {
        public string Name { get; private set; } = null!;
        public string Icon { get; private set; } = null!;
        public string Color { get; private set; } = null!;
        public string Url { get; private set; } = null!;
        public Guid PortfolioId { get; private set; }

        public SocialMedia(string name, string icon, string color, string url, Guid portfolioId)
        {
            Name = name;
            Icon = icon;
            Color = color;
            Url = url;
            PortfolioId = portfolioId;
        }

        public void Update(string name, string icon, string color, string url)
        {
            Name = name;
            Icon = icon;
            Color = color;
            Url = url;
            SetUpdated();
        }
    }
}
