using System.ComponentModel.DataAnnotations.Schema;

namespace Base.Domain.Entities
{
    public class PostTechnology : BaseEntity
    {
        public Guid PostId { get; private set; }
        public Guid TechnologyId { get; private set; }

        public PostTechnology(Guid postId, Guid technologyId)
        {
            PostId = postId;
            TechnologyId = technologyId;
        }
    }
}
