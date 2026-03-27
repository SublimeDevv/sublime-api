namespace Base.Application.DTOs.Posts
{
    public class PostDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = null!;
        public string? CoverImage { get; set; }
        public string? Description { get; set; }
        public string? Content { get; set; }
        public bool IsPublic { get; set; }
        public string Slug { get; set; } = null!;
        public string UserId { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
