using System.ComponentModel.DataAnnotations.Schema;

namespace Base.Domain.Entities
{
    public class PostCategory : BaseEntity
    {
        public Guid PostId { get; private set; }
        public Guid CategoryId { get; private set; }

        public PostCategory(Guid postId, Guid categoryId)
        {
            PostId = postId;
            CategoryId = categoryId;
        }
    }
}
