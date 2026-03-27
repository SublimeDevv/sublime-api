using Base.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Base.Infraestructure.Configurations
{
    public class PostTechnologyConfig : IEntityTypeConfiguration<PostTechnology>
    {
        public void Configure(EntityTypeBuilder<PostTechnology> builder)
        {
            builder.ToTable("PostTechnologies");
            builder.HasKey(pt => pt.Id);
            builder.Property(pt => pt.Id).HasColumnType("uniqueidentifier");
            builder.Property(pt => pt.PostId).IsRequired().HasColumnType("uniqueidentifier");
            builder.Property(pt => pt.TechnologyId).IsRequired().HasColumnType("uniqueidentifier");
            builder.Property(pt => pt.CreatedAt).IsRequired().HasColumnType("datetime2");
            builder.Property(pt => pt.UpdatedAt).HasColumnType("datetime2");
            builder.Property(pt => pt.IsDeleted).IsRequired().HasColumnType("bit");
            builder.Property(pt => pt.DeletedAt).HasColumnType("datetime2");

            builder.HasIndex(pt => new { pt.PostId, pt.TechnologyId });
        }
    }
}
