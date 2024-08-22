using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RetroRemedy.Core.Entities.GameTags;

namespace RetroRemedy.Infrastructure.Configuration.Mappings;

public class GameTagMapping:IEntityTypeConfiguration<GameTag>
{
    public void Configure(EntityTypeBuilder<GameTag> builder)
    {
        builder.ToTable("GameTags");
        builder.HasKey(x => x.Id);
                
        builder.Property(x => x.CreateDateTime)
            .IsRequired();
        
        builder.Property(x => x.IsRemoved)
            .IsRequired();

        builder.Property(x => x.GameId).IsRequired();
        builder.Property(x => x.TagId).IsRequired();

        builder.HasOne(x => x.Game).WithMany(x => x.GameTags).HasForeignKey(x => x.GameId);
        builder.HasOne(x => x.Tag).WithMany(x => x.GameTags).HasForeignKey(x => x.TagId);
    }
}