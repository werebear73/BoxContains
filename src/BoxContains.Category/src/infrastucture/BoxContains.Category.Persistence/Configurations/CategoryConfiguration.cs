using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BoxContains.Category.Persistence.Configurations;

public class CategoryConfiguration : IEntityTypeConfiguration<Domain.Category>
{
    public void Configure(EntityTypeBuilder<Domain.Category> builder)
    {
        builder.ToTable("category");

        builder.HasKey(c => c.CategoryID);

        builder.Property(c => c.CategoryID)
            .HasColumnName("category_id")
            .UseSequence();

        builder.Property(c => c.Name)
            .HasColumnName("name")
            .IsRequired()
            .HasMaxLength(255);
    }
}
