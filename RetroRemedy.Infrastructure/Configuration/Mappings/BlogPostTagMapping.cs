using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RetroRemedy.Core.Entities.BlogPostTags;

namespace RetroRemedy.Infrastructure.Configuration.Mappings;

public class BlogPostTagMapping : IEntityTypeConfiguration<BlogPostTag>
{
    public void Configure(EntityTypeBuilder<BlogPostTag> builder)
    {
        builder.ToTable("BlogPostTags");
        builder.HasKey(x => x.Id);
                
        builder.Property(x => x.CreateDateTime)
            .IsRequired();
                
        builder.Property(x => x.IsRemoved)
            .IsRequired();

        builder.Property(x => x.BlogPostId).IsRequired();
        builder.Property(x => x.TagId).IsRequired();

        builder.HasOne(x => x.Tag).WithMany(x => x.BlogPostTags).HasForeignKey(x=>x.TagId);
        
        builder.HasOne(x => x.BlogPost).WithMany(x => x.BlogPostTags).HasForeignKey(x=>x.BlogPostId);
    }
}