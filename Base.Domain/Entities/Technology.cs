using System.ComponentModel.DataAnnotations.Schema;

namespace Base.Domain.Entities
{
    public class Technology : BaseEntity
    {
        public string Name { get; private set; } = null!;
        public string Description { get; private set; } = null!;
        public string Icon { get; private set; } = null!;
        public string Color { get; private set; } = null!;

        public Technology(string name, string description, string icon, string color)
        {
            Name = name;
            Description = description;
            Icon = icon;
            Color = color;
        }

        public void Update(string name, string description, string icon, string color)
        {
            Name = name;
            Description = description;
            Icon = icon;
            Color = color;
            SetUpdated();
        }
    }
}
