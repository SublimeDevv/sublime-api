namespace Base.Application.DTOs.Projects
{
    public class ProjectDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public string? UrlSite { get; set; }
        public string? UrlRepository { get; set; }
        public bool IsActive { get; set; }
        public string Slug { get; set; } = null!;
        public Guid PortfolioId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
