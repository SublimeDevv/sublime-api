using System.ComponentModel.DataAnnotations.Schema;

namespace Base.Domain.Entities
{
    public class SoftSkill : BaseEntity
    {
        public string? Name { get; private set; }
        public string Description { get; private set; } = null!;
        public bool IsActive { get; private set; }
        public Guid PortfolioId { get; private set; }

        public SoftSkill(string? name, string description, bool isActive, Guid portfolioId)
        {
            Name = name;
            Description = description;
            IsActive = isActive;
            PortfolioId = portfolioId;
        }

        public void Update(string? name, string description, bool isActive)
        {
            Name = name;
            Description = description;
            IsActive = isActive;
            SetUpdated();
        }
    }
}
