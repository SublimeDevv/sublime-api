using Base.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Base.Infraestructure.Configurations
{
    public class CategoryConfig : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("Categories");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).HasColumnType("uniqueidentifier");
            builder.Property(c => c.Name).IsRequired().HasMaxLength(200).HasColumnType("nvarchar(200)");
            builder.Property(c => c.Description).HasMaxLength(500).HasColumnType("nvarchar(500)");
            builder.Property(c => c.Icon).IsRequired().HasMaxLength(500).HasColumnType("nvarchar(500)");
            builder.Property(c => c.Color).IsRequired().HasMaxLength(50).HasColumnType("nvarchar(50)");
            builder.Property(c => c.CreatedAt).IsRequired().HasColumnType("datetime2");
            builder.Property(c => c.UpdatedAt).HasColumnType("datetime2");
            builder.Property(c => c.IsDeleted).IsRequired().HasColumnType("bit");
            builder.Property(c => c.DeletedAt).HasColumnType("datetime2");
        }
    }
}
