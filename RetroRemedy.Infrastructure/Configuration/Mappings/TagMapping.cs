using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RetroRemedy.Core.Entities.Tags;

namespace RetroRemedy.Infrastructure.Configuration.Mappings;

public class TagMapping:IEntityTypeConfiguration<Tag>
{
    public void Configure(EntityTypeBuilder<Tag> builder)
    {
        builder.ToTable("Tags");
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

        builder.HasMany(x => x.GameTags).WithOne(x => x.Tag).HasForeignKey(x => x.TagId);
        
        builder.HasMany(x => x.BlogPostTags).WithOne(x => x.Tag).HasForeignKey(x => x.TagId);
    }
}