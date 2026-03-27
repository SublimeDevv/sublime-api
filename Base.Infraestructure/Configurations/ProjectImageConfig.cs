using Base.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Base.Infraestructure.Configurations
{
    public class ProjectImageConfig : IEntityTypeConfiguration<ProjectImage>
    {
        public void Configure(EntityTypeBuilder<ProjectImage> builder)
        {
            builder.ToTable("ProjectImages");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).HasColumnType("uniqueidentifier");
            builder.Property(p => p.UrlImage).IsRequired().HasMaxLength(1000).HasColumnType("nvarchar(1000)");
            builder.Property(p => p.ProjectId).IsRequired().HasColumnType("uniqueidentifier");
            builder.Property(p => p.CreatedAt).IsRequired().HasColumnType("datetime2");
            builder.Property(p => p.UpdatedAt).HasColumnType("datetime2");
            builder.Property(p => p.IsDeleted).IsRequired().HasColumnType("bit");
            builder.Property(p => p.DeletedAt).HasColumnType("datetime2");

            builder.HasIndex(p => p.ProjectId);
        }
    }
}
