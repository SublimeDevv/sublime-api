namespace Base.Application.DTOs.ProjectImages
{
    public class ProjectImageDto
    {
        public Guid Id { get; set; }
        public string UrlImage { get; set; } = null!;
        public Guid ProjectId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
