using Base.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Base.Infraestructure.Configurations
{
    public class SoftSkillConfig : IEntityTypeConfiguration<SoftSkill>
    {
        public void Configure(EntityTypeBuilder<SoftSkill> builder)
        {
            builder.ToTable("SoftSkills");
            builder.HasKey(s => s.Id);
            builder.Property(s => s.Id).HasColumnType("uniqueidentifier");
            builder.Property(s => s.Name).HasMaxLength(200).HasColumnType("nvarchar(200)");
            builder.Property(s => s.Description).IsRequired().HasColumnType("nvarchar(max)");
            builder.Property(s => s.IsActive).IsRequired().HasColumnType("bit");
            builder.Property(s => s.PortfolioId).IsRequired().HasColumnType("uniqueidentifier");
            builder.Property(s => s.CreatedAt).IsRequired().HasColumnType("datetime2");
            builder.Property(s => s.UpdatedAt).HasColumnType("datetime2");
            builder.Property(s => s.IsDeleted).IsRequired().HasColumnType("bit");
            builder.Property(s => s.DeletedAt).HasColumnType("datetime2");

            builder.HasIndex(s => s.PortfolioId);
        }
    }
}
