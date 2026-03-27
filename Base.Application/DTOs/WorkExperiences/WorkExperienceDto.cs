namespace Base.Application.DTOs.WorkExperiences
{
    public class WorkExperienceDto
    {
        public Guid Id { get; set; }
        public string? Title { get; set; }
        public string Description { get; set; } = null!;
        public bool IsActive { get; set; }
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }
        public Guid PortfolioId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
