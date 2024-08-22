using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RetroRemedy.Core.Entities.Games;
using RetroRemedy.Core.Entities.UploadMedias;

namespace RetroRemedy.Infrastructure.Configuration.Mappings;

public class UploadFileMapping : IEntityTypeConfiguration<UploadFile>
{
    public void Configure(EntityTypeBuilder<UploadFile> builder)
    {
        builder.ToTable("UploadFiles");
        builder.HasKey(x => x.Id);

        builder.Property(x => x.AltText).HasMaxLength(64).IsRequired();
        builder.Property(x => x.Caption).HasMaxLength(256).IsRequired();
        
        builder.Property(x => x.FilePath).IsRequired();
        builder.Property(x => x.WebUrl).IsRequired();
        builder.Property(x => x.Order).HasDefaultValue(0).IsRequired();

        builder.HasOne(x => x.Publisher).WithOne(x => x.Thumbnail).HasForeignKey<UploadFile>(x => x.PublisherId);


        builder.HasOne(x => x.Game)
            .WithMany(x => x.Medias)
            .HasForeignKey(x => x.GameId)
            .OnDelete(DeleteBehavior.SetNull);

        builder.HasOne(x => x.BlogPost)
            .WithMany(x => x.Medias)
            .HasForeignKey(x => x.BlogPostId)
            .OnDelete(DeleteBehavior.SetNull);
    }
}