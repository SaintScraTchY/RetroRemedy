using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RetroRemedy.Core.Entities.AppUsers;
using RetroRemedy.Core.Entities.BlogPosts;
using RetroRemedy.Core.Entities.BlogPostTags;
using RetroRemedy.Core.Entities.Categories;
using RetroRemedy.Core.Entities.Comments;
using RetroRemedy.Core.Entities.GameCategories;
using RetroRemedy.Core.Entities.Games;
using RetroRemedy.Core.Entities.GameTags;
using RetroRemedy.Core.Entities.Publishers;
using RetroRemedy.Core.Entities.Tags;
using RetroRemedy.Core.Entities.UploadMedias;
using RetroRemedy.Infrastructure.Configuration.Mappings;

namespace RetroRemedy.Infrastructure;

public class RetroContext : IdentityDbContext<AppUser,IdentityRole<long>,long>  
{
    public RetroContext(DbContextOptions<RetroContext> options):base(options)
    {
        
    }

    public DbSet<Publisher> Publishers { get; set; }
    public DbSet<Tag> Tags { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Game> Games { get; set; }
    public DbSet<GameTag> GameTags { get; set; }
    public DbSet<GameCategory> GameCategories { get; set; }

    public DbSet<UploadMedia> UploadMedias { get; set; }
    public DbSet<Comment> Comments { get; set; }
    public DbSet<BlogPost> BlogPosts { get; set; }
    public DbSet<BlogPostTag> BlogPostTags { get; set; }
    
    //TODO Add Others Later On

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(typeof(TagMapping).Assembly);
    }
}