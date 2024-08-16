using RetroRemedy.Core.Common;
using RetroRemedy.Core.Entities.AppUsers;
using RetroRemedy.Core.Entities.BlogPostTags;
using RetroRemedy.Core.Entities.Categories;
using RetroRemedy.Core.Entities.Games;

namespace RetroRemedy.Core.Entities.BlogPosts;

public class BlogPost : BaseEntity
{
    public string Title { get; set; }
    public string Content { get; set; }
    public long AuthorIds { get; set; }
    public AppUser Author { get; set; }
    public long GameId { get; set; }
    public Game Game { get; set; }
    public bool IsPublished { get; set; }
    public DateTime PublishedDateTime { get; set; }
    public string Slug { get; set; }
    public string Excerpt { get; set; }
    public long CategoryId { get; set; }
    public Category Category { get; set; }
    public ICollection<BlogPostTag> BlogPostTags { get; set; }

    protected BlogPost(string title, string content, long authorIds, long gameId, string slug, 
        string excerpt, long categoryId, long userId) : base(userId, true)
    {
        Title = title;
        Content = content;
        AuthorIds = authorIds;
        GameId = gameId;
        Slug = slug;
        Excerpt = excerpt;
        CategoryId = categoryId;
    }

    public void Publish(long userId)
    {
        base.UpdateTimestamp(userId);
        IsRemoved = false;
        IsActive = true;
        IsPublished = true;
        PublishedDateTime = UpdateDateTime;
    }
}