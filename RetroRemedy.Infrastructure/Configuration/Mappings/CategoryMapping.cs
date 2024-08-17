using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RetroRemedy.Core.Entities.Categories;

namespace RetroRemedy.Infrastructure.Configuration.Mappings;

public class CategoryMapping : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.ToTable("Categories");
        builder.HasKey(x => x.Id);
        builder.Ignore(x => x.RowVersion);

        builder.Property(x => x.CreateDateTime)
            .IsRequired();
        
        builder.Property(x => x.CreatedById)
            .IsRequired();

        builder.Property(x => x.UpdateDateTime)
            .IsRequired(false);
        
        builder.Property(x => x.UpdatedById)
            .IsRequired(false);

        builder.Property(x => x.IsActive)
            .IsRequired();

        builder.Property(x => x.IsRemoved)
            .IsRequired();

        builder.Property(x => x.Name)
            .HasMaxLength(96)
            .IsRequired();

        builder.HasMany(x => x.BlogPosts)
            .WithOne(x => x.Category)
            .HasForeignKey(x => x.CategoryId);
        
        builder.HasMany(x => x.GameCategories)
            .WithOne(x => x.Category)
            .HasForeignKey(x => x.CategoryId);
    }
}