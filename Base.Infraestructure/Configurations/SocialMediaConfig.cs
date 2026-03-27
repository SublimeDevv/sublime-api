using Base.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Base.Infraestructure.Configurations
{
    public class SocialMediaConfig : IEntityTypeConfiguration<SocialMedia>
    {
        public void Configure(EntityTypeBuilder<SocialMedia> builder)
        {
            builder.ToTable("SocialMedia");
            builder.HasKey(s => s.Id);
            builder.Property(s => s.Id).HasColumnType("uniqueidentifier");
            builder.Property(s => s.Name).IsRequired().HasMaxLength(200).HasColumnType("nvarchar(200)");
            builder.Property(s => s.Icon).IsRequired().HasMaxLength(500).HasColumnType("nvarchar(500)");
            builder.Property(s => s.Color).IsRequired().HasMaxLength(50).HasColumnType("nvarchar(50)");
            builder.Property(s => s.Url).IsRequired().HasMaxLength(1000).HasColumnType("nvarchar(1000)");
            builder.Property(s => s.PortfolioId).IsRequired().HasColumnType("uniqueidentifier");
            builder.Property(s => s.CreatedAt).IsRequired().HasColumnType("datetime2");
            builder.Property(s => s.UpdatedAt).HasColumnType("datetime2");
            builder.Property(s => s.IsDeleted).IsRequired().HasColumnType("bit");
            builder.Property(s => s.DeletedAt).HasColumnType("datetime2");

            builder.HasIndex(s => s.PortfolioId);

            builder.HasQueryFilter(c => !c.IsDeleted);
        }
    }
}
