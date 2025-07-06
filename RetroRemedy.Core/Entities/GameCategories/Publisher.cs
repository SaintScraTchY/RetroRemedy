using RetroRemedy.Core.Common;
using RetroRemedy.Core.Entities.UploadMedias;

namespace RetroRemedy.Core.Entities.GameCategories;

public class Publisher : BaseEntity
{
    public string Name { get; private set; }
    public string Description { get; private set; }
    public string Slug { get; private set; }
    public string MetaDescription { get; private set; }
    public string KeyWords { get; private set; }
    public string WebsiteUrl { get; private set; }
    public string WikipediaUrl { get; private set; }
    //Add Vote Implementation
    public float Rating { get; private set; }
    public UploadFile Thumbnail { get; set; }
    public long ThumbnailId { get; private set; }
    public ICollection<Game> Games { get; set; }

    protected Publisher()
    {
        
    }
    public Publisher(string name, string description, string slug, string metaDescription, string keyWords,
        string websiteUrl, string wikipediaUrl, UploadFile thumbnail, long userId) : base(userId, true)
    {
        Name = name;
        Description = description;
        Slug = slug;
        MetaDescription = metaDescription;
        KeyWords = keyWords;
        WebsiteUrl = websiteUrl;
        WikipediaUrl = wikipediaUrl;
        Rating = 0;
        Thumbnail = thumbnail;
    }
    
    public void Update(string name, string description, string slug, string metaDescription, string keyWords,
        string websiteUrl, string wikipediaUrl, long userId)
    {
        UpdateTimestamp(userId);
        Name = name;
        Description = description;
        Slug = slug;
        MetaDescription = metaDescription;
        KeyWords = keyWords;
        WebsiteUrl = websiteUrl;
        WikipediaUrl = wikipediaUrl;
        Rating = 0;
    }

    public void SetThumbnail(long thumbnailId)
    {
        ThumbnailId = thumbnailId;
    }
}