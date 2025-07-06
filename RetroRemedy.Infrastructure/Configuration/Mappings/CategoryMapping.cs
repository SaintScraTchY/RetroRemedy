using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RetroRemedy.Core.Entities.LabelEntities;

namespace RetroRemedy.Infrastructure.Configuration.Mappings;

public class CategoryMapping : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.ToTable("Categories");
        builder.HasKey(x => x.Id);

        builder.Property(x => x.CreateDateTime)
            .IsRequired();
        
        builder.Property(x => x.IsRemoved)
            .IsRequired();

        builder.Property(x => x.Name)
            .HasMaxLength(96)
            .IsRequired();
        
        builder.Property(x => x.Slug)
            .IsRequired();
        
        builder.Property(x => x.MetaDescription)
            .IsRequired();
        
        builder.Property(x => x.KeyWords)
            .IsRequired();
        
        builder.Property(x => x.IconId)
            .IsRequired();

        builder.HasMany(x => x.BlogPosts)
            .WithOne(x => x.Category)
            .HasForeignKey(x => x.CategoryId);
        
        builder.HasMany(x => x.GameCategories)
            .WithOne(x => x.Category)
            .HasForeignKey(x => x.CategoryId);
    }
}