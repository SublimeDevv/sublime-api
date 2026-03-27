using System.ComponentModel.DataAnnotations.Schema;

namespace Base.Domain.Entities
{
    public class Category : BaseEntity
    {
        public string Name { get; private set; } = null!;
        public string? Description { get; private set; }
        public string Icon { get; private set; } = null!;
        public string Color { get; private set; } = null!;

        public Category(string name, string? description, string icon, string color)
        {
            Name = name;
            Description = description;
            Icon = icon;
            Color = color;
        }

        public void Update(string name, string? description, string icon, string color)
        {
            Name = name;
            Description = description;
            Icon = icon;
            Color = color;
            SetUpdated();
        }
    }
}
