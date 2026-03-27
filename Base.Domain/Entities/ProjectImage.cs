using System.ComponentModel.DataAnnotations.Schema;

namespace Base.Domain.Entities
{
    public class ProjectImage : BaseEntity
    {
        public string UrlImage { get; private set; } = null!;
        public Guid ProjectId { get; private set; }

        public ProjectImage(string urlImage, Guid projectId)
        {
            UrlImage = urlImage;
            ProjectId = projectId;
        }

        public void Update(string urlImage)
        {
            UrlImage = urlImage;
            SetUpdated();
        }
    }
}
