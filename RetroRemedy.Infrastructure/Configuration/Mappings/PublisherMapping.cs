using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RetroRemedy.Core.Entities.Publishers;

namespace RetroRemedy.Infrastructure.Configuration.Mappings;

public class PublisherMapping : IEntityTypeConfiguration<Publisher>
{
    public void Configure(EntityTypeBuilder<Publisher> builder)
    {
        builder.ToTable("Publishers");
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
        
        builder.Property(x => x.Slug)
            .HasMaxLength(160)
            .IsRequired();
                
        builder.Property(x => x.MetaDescription)
            .HasMaxLength(512)
            .IsRequired();

        builder.Property(x => x.KeyWords)
            .HasMaxLength(128).IsRequired();

        builder.HasOne(x => x.Thumbnail).WithOne(x => x.Publisher).HasForeignKey<Publisher>(x => x.ThumbnailId);
    }
}