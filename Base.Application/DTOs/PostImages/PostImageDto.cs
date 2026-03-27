namespace Base.Application.DTOs.PostImages
{
    public class PostImageDto
    {
        public Guid Id { get; set; }
        public string ImageUrl { get; set; } = null!;
        public int Order { get; set; }
        public Guid PostId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
