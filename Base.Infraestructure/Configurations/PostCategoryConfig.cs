using Base.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Base.Infraestructure.Configurations
{
    public class PostCategoryConfig : IEntityTypeConfiguration<PostCategory>
    {
        public void Configure(EntityTypeBuilder<PostCategory> builder)
        {
            builder.ToTable("PostCategories");
            builder.HasKey(pc => pc.Id);
            builder.Property(pc => pc.Id).HasColumnType("uniqueidentifier");
            builder.Property(pc => pc.PostId).IsRequired().HasColumnType("uniqueidentifier");
            builder.Property(pc => pc.CategoryId).IsRequired().HasColumnType("uniqueidentifier");
            builder.Property(pc => pc.CreatedAt).IsRequired().HasColumnType("datetime2");
            builder.Property(pc => pc.UpdatedAt).HasColumnType("datetime2");
            builder.Property(pc => pc.IsDeleted).IsRequired().HasColumnType("bit");
            builder.Property(pc => pc.DeletedAt).HasColumnType("datetime2");

            builder.HasIndex(pc => new { pc.PostId, pc.CategoryId });

            builder.HasQueryFilter(c => !c.IsDeleted);
        }
    }
}
