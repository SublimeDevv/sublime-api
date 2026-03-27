using Base.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Base.Infraestructure.Configurations
{
    public class ProjectConfig : IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> builder)
        {
            builder.ToTable("Projects");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).HasColumnType("uniqueidentifier");
            builder.Property(p => p.Name).IsRequired().HasMaxLength(200).HasColumnType("nvarchar(200)");
            builder.Property(p => p.Description).HasColumnType("nvarchar(max)");
            builder.Property(p => p.UrlSite).HasMaxLength(1000).HasColumnType("nvarchar(1000)");
            builder.Property(p => p.UrlRepository).HasMaxLength(1000).HasColumnType("nvarchar(1000)");
            builder.Property(p => p.IsActive).IsRequired().HasColumnType("bit");
            builder.Property(p => p.Slug).IsRequired().HasMaxLength(300).HasColumnType("nvarchar(300)");
            builder.Property(p => p.PortfolioId).IsRequired().HasColumnType("uniqueidentifier");
            builder.Property(p => p.CreatedAt).IsRequired().HasColumnType("datetime2");
            builder.Property(p => p.UpdatedAt).HasColumnType("datetime2");
            builder.Property(p => p.IsDeleted).IsRequired().HasColumnType("bit");
            builder.Property(p => p.DeletedAt).HasColumnType("datetime2");

            builder.HasIndex(p => p.PortfolioId);
        }
    }
}
