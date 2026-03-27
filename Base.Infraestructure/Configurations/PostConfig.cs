using Base.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Base.Infraestructure.Configurations
{
    public class PostConfig : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.ToTable("Posts");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).HasColumnType("uniqueidentifier");
            builder.Property(p => p.Title).IsRequired().HasMaxLength(300).HasColumnType("nvarchar(300)");
            builder.Property(p => p.CoverImage).HasMaxLength(1000).HasColumnType("nvarchar(1000)");
            builder.Property(p => p.Description).HasColumnType("nvarchar(max)");
            builder.Property(p => p.Content).HasColumnType("nvarchar(max)");
            builder.Property(p => p.IsPublic).IsRequired().HasColumnType("bit");
            builder.Property(p => p.Slug).IsRequired().HasMaxLength(300).HasColumnType("nvarchar(300)");
            builder.Property(p => p.UserId).IsRequired().HasMaxLength(450).HasColumnType("nvarchar(450)");
            builder.Property(p => p.CreatedAt).IsRequired().HasColumnType("datetime2");
            builder.Property(p => p.UpdatedAt).HasColumnType("datetime2");
            builder.Property(p => p.IsDeleted).IsRequired().HasColumnType("bit");
            builder.Property(p => p.DeletedAt).HasColumnType("datetime2");

            builder.HasQueryFilter(c => !c.IsDeleted);
        }
    }
}
