using System.ComponentModel.DataAnnotations.Schema;

namespace Base.Domain.Entities
{
    public class Post : BaseEntity
    {
        public string Title { get; private set; } = null!;
        public string? CoverImage { get; private set; }
        public string? Description { get; private set; }
        public string? Content { get; private set; }
        public bool IsPublic { get; private set; }
        public string Slug { get; private set; } = null!;
        public string UserId { get; private set; } = null!;

        public Post(string title, string? coverImage, string? description, string? content, bool isPublic, string slug, string userId)
        {
            Title = title;
            CoverImage = coverImage;
            Description = description;
            Content = content;
            IsPublic = isPublic;
            Slug = slug;
            UserId = userId;
        }

        public void Update(string title, string? coverImage, string? description, string? content, bool isPublic, string slug)
        {
            Title = title;
            CoverImage = coverImage;
            Description = description;
            Content = content;
            IsPublic = isPublic;
            Slug = slug;
            SetUpdated();
        }
    }
}
