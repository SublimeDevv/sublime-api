namespace Base.Application.DTOs.SocialsMedia
{
    public class SocialMediaDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string Icon { get; set; } = null!;
        public string Color { get; set; } = null!;
        public string Url { get; set; } = null!;
        public Guid PortfolioId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
