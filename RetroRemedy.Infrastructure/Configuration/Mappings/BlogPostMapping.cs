using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RetroRemedy.Core.Entities.BlogPosts;

namespace RetroRemedy.Infrastructure.Configuration.Mappings;

public class BlogPostMapping : IEntityTypeConfiguration<BlogPost>
{
    public void Configure(EntityTypeBuilder<BlogPost> builder)
    {
        builder.ToTable("BlogPosts");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.RowVersion).IsRowVersion();
        
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

        builder.Property(x => x.Title)
            .HasMaxLength(256)
            .IsRequired();

        builder.Property(x => x.Rating)
            .IsRequired();

        builder.Property(x => x.Title)
            .HasMaxLength(256)
            .IsRequired();

        builder.Property(x => x.Content).IsRequired();

        builder.Property(x => x.Slug)
            .HasMaxLength(160)
            .IsRequired();
        
        builder.Property(x => x.MetaDescription)
            .HasMaxLength(512)
            .IsRequired();

        builder.Property(x => x.KeyWords)
            .HasMaxLength(128).IsRequired();

        builder.Property(x => x.Excerpt)
            .IsRequired();

        builder.Property(x => x.IsPublished).IsRequired();

        builder.HasOne(x => x.CreatedBy)
            .WithMany(x => x.BlogPosts)
            .HasForeignKey(x => x.CreatedById);

        builder.HasOne(x => x.Category)
            .WithMany(x => x.BlogPosts)
            .HasForeignKey(x => x.CategoryId);

        builder.HasMany(x => x.BlogPostTags)
            .WithOne(x => x.BlogPost)
            .HasForeignKey(x => x.BlogPostId);

        builder.HasMany(x => x.Medias)
            .WithOne(x => x.BlogPost)
            .HasForeignKey(x => x.BlogPostId);
    }
}