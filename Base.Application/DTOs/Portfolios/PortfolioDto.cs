namespace Base.Application.DTOs.Portfolios
{
    public class PortfolioDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string AboutMe { get; set; } = null!;
        public string? EmailContact { get; set; }
        public string? Phone { get; set; }
        public bool IsActive { get; set; }
        public string Slug { get; set; } = null!;
        public string UserId { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
