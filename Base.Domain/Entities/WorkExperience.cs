using System.ComponentModel.DataAnnotations.Schema;

namespace Base.Domain.Entities
{
    public class WorkExperience : BaseEntity
    {
        public string? Title { get; private set; }
        public string Description { get; private set; } = null!;
        public bool IsActive { get; private set; }
        public DateOnly StartDate { get; private set; }
        public DateOnly EndDate { get; private set; }
        public Guid PortfolioId { get; private set; }

        public WorkExperience(string? title, string description, bool isActive, DateOnly startDate, DateOnly endDate, Guid portfolioId)
        {
            Title = title;
            Description = description;
            IsActive = isActive;
            StartDate = startDate;
            EndDate = endDate;
            PortfolioId = portfolioId;
        }

        public void Update(string? title, string description, bool isActive, DateOnly startDate, DateOnly endDate)
        {
            Title = title;
            Description = description;
            IsActive = isActive;
            StartDate = startDate;
            EndDate = endDate;
            SetUpdated();
        }
    }
}
