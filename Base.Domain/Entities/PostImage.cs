using System.ComponentModel.DataAnnotations.Schema;

namespace Base.Domain.Entities
{
    public class PostImage : BaseEntity
    {
        public string ImageUrl { get; private set; } = null!;
        public int Order { get; private set; }
        public Guid PostId { get; private set; }

        public PostImage(string imageUrl, int order, Guid postId)
        {
            ImageUrl = imageUrl;
            Order = order;
            PostId = postId;
        }

        public void Update(string imageUrl, int order)
        {
            ImageUrl = imageUrl;
            Order = order;
            SetUpdated();
        }
    }
}
