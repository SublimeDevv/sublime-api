using Base.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Base.Infraestructure.Configurations
{
    public class WorkExperienceConfig : IEntityTypeConfiguration<WorkExperience>
    {
        public void Configure(EntityTypeBuilder<WorkExperience> builder)
        {
            builder.ToTable("WorkExperiencies");
            builder.HasKey(w => w.Id);
            builder.Property(w => w.Id).HasColumnType("uniqueidentifier");
            builder.Property(w => w.Title).HasMaxLength(300).HasColumnType("nvarchar(300)");
            builder.Property(w => w.Description).IsRequired().HasColumnType("nvarchar(max)");
            builder.Property(w => w.IsActive).IsRequired().HasColumnType("bit");
            builder.Property(w => w.StartDate).IsRequired().HasColumnType("date");
            builder.Property(w => w.EndDate).IsRequired().HasColumnType("date");
            builder.Property(w => w.PortfolioId).IsRequired().HasColumnType("uniqueidentifier");
            builder.Property(w => w.CreatedAt).IsRequired().HasColumnType("datetime2");
            builder.Property(w => w.UpdatedAt).HasColumnType("datetime2");
            builder.Property(w => w.IsDeleted).IsRequired().HasColumnType("bit");
            builder.Property(w => w.DeletedAt).HasColumnType("datetime2");

            builder.HasIndex(w => w.PortfolioId);
        }
    }
}
