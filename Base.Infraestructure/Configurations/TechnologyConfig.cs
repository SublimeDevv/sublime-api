using Base.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Base.Infraestructure.Configurations
{
    public class TechnologyConfig : IEntityTypeConfiguration<Technology>
    {
        public void Configure(EntityTypeBuilder<Technology> builder)
        {
            builder.ToTable("Technologies");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Id).HasColumnType("uniqueidentifier");
            builder.Property(t => t.Name).IsRequired().HasMaxLength(200).HasColumnType("nvarchar(200)");
            builder.Property(t => t.Description).IsRequired().HasColumnType("nvarchar(max)");
            builder.Property(t => t.Icon).IsRequired().HasMaxLength(500).HasColumnType("nvarchar(500)");
            builder.Property(t => t.Color).IsRequired().HasMaxLength(50).HasColumnType("nvarchar(50)");
            builder.Property(t => t.CreatedAt).IsRequired().HasColumnType("datetime2");
            builder.Property(t => t.UpdatedAt).HasColumnType("datetime2");
            builder.Property(t => t.IsDeleted).IsRequired().HasColumnType("bit");
            builder.Property(t => t.DeletedAt).HasColumnType("datetime2");

            builder.HasQueryFilter(c => !c.IsDeleted);
        }
    }
}
