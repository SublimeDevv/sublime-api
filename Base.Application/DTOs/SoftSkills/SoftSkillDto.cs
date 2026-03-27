namespace Base.Application.DTOs.SoftSkills
{
    public class SoftSkillDto
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string Description { get; set; } = null!;
        public bool IsActive { get; set; }
        public Guid PortfolioId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
