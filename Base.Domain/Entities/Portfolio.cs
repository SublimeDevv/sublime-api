using System.ComponentModel.DataAnnotations.Schema;

namespace Base.Domain.Entities
{
    public class Portfolio : BaseEntity
    {
        public string Name { get; private set; } = null!;
        public string Description { get; private set; } = null!;
        public string AboutMe { get; private set; } = null!;
        public string? EmailContact { get; private set; }
        public string? Phone { get; private set; }
        public bool IsActive { get; private set; }
        public string Slug { get; private set; } = null!;
        public string UserId { get; private set; } = null!;

        public Portfolio(string name, string description, string aboutMe, string? emailContact, string? phone, bool isActive, string slug, string userId)
        {
            Name = name;
            Description = description;
            AboutMe = aboutMe;
            EmailContact = emailContact;
            Phone = phone;
            IsActive = isActive;
            Slug = slug;
            UserId = userId;
        }

        public void Update(string name, string description, string aboutMe, string? emailContact, string? phone, bool isActive, string slug)
        {
            Name = name;
            Description = description;
            AboutMe = aboutMe;
            EmailContact = emailContact;
            Phone = phone;
            IsActive = isActive;
            Slug = slug;
            SetUpdated();
        }
    }
}
