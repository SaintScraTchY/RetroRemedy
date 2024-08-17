using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RetroRemedy.Core.Entities.Games;

namespace RetroRemedy.Infrastructure.Configuration.Mappings;

public class GameMapping:IEntityTypeConfiguration<Game>
{
    public void Configure(EntityTypeBuilder<Game> builder)
    {
        builder.ToTable("Games");
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

        builder.HasMany(x => x.GameTags)
            .WithOne(x => x.Game)
            .HasForeignKey(x => x.GameId);

        builder.HasMany(x => x.BlogPosts)
            .WithOne(x => x.Game)
            .HasForeignKey(x => x.GameId);

        builder.HasMany(x => x.Medias)
            .WithOne(x => x.Game)
            .HasForeignKey(x => x.GameId);
        
        builder.HasOne(x => x.Publisher)
            .WithMany(x => x.Games)
            .HasForeignKey(x => x.PublisherId);
    }
}