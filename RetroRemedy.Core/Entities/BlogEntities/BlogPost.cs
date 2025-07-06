using RetroRemedy.Core.Common;
using RetroRemedy.Core.Entities.GameCategories;
using RetroRemedy.Core.Entities.LabelEntities;
using RetroRemedy.Core.Entities.UploadMedias;

namespace RetroRemedy.Core.Entities.BlogEntities;

public class BlogPost : BaseEntity
{
    public string Title { get; private set; }
    public bool IsPublished { get; private set; }
    public DateTime? PublishedDateTime { get; private set; }
    public float? Rating { get; private set; }
    public bool IsMultiLanguagePost { get; private set; }

    #region SEO
    
    public string MetaTitle { get; private set; }
    public string Slug { get; private set; }
    public string MetaDescription { get; private set; }
    public string KeyWords { get; private set; }
    public string Excerpt { get; private set; }
    
    #endregion
    
    public long? GameId { get; private set; }
    public Game? Game { get; private set; }
    public long? CategoryId { get; private set; }
    public Category? Category { get; private set; }

    public ICollection<BlogPostContent> PostContents { get; set; }
    public ICollection<UploadFile> Medias { get; set; }
    public ICollection<BlogPostTag> BlogPostTags { get; set; }

    protected BlogPost()
    {
        
    }
    
    public BlogPost(string title,long gameId, string slug, 
        string excerpt, long categoryId, long userId) : base(userId, true)
    {
        Title = title;
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
        PublishedDateTime = UpdateDateTime ?? DateTime.UtcNow;
    }
}