using Base.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Base.Infraestructure.Configurations
{
    public class PortfolioConfig : IEntityTypeConfiguration<Portfolio>
    {
        public void Configure(EntityTypeBuilder<Portfolio> builder)
        {
            builder.ToTable("Portfolio");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).HasColumnType("uniqueidentifier");
            builder.Property(p => p.Name).IsRequired().HasMaxLength(200).HasColumnType("nvarchar(200)");
            builder.Property(p => p.Description).IsRequired().HasColumnType("nvarchar(max)");
            builder.Property(p => p.AboutMe).IsRequired().HasColumnType("nvarchar(max)");
            builder.Property(p => p.EmailContact).HasMaxLength(256).HasColumnType("nvarchar(256)");
            builder.Property(p => p.Phone).HasMaxLength(30).HasColumnType("nvarchar(30)");
            builder.Property(p => p.IsActive).IsRequired().HasColumnType("bit");
            builder.Property(p => p.Slug).IsRequired().HasMaxLength(300).HasColumnType("nvarchar(300)");
            builder.Property(p => p.UserId).IsRequired().HasMaxLength(450).HasColumnType("nvarchar(450)");
            builder.Property(p => p.CreatedAt).IsRequired().HasColumnType("datetime2");
            builder.Property(p => p.UpdatedAt).HasColumnType("datetime2");
            builder.Property(p => p.IsDeleted).IsRequired().HasColumnType("bit");
            builder.Property(p => p.DeletedAt).HasColumnType("datetime2");
        }
    }
}
