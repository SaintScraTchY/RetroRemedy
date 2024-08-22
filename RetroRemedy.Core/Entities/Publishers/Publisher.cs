using RetroRemedy.Core.Common;
using RetroRemedy.Core.Entities.Games;
using RetroRemedy.Core.Entities.UploadMedias;

namespace RetroRemedy.Core.Entities.Publishers;

public class Publisher : BaseEntity
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string Slug { get; set; }
    public string MetaDescription { get; set; }
    public string KeyWords { get; set; }
    public string WebsiteUrl { get; set; }
    public string WikipediaUrl { get; set; }
    //Add Vote Implementation
    public float Rating { get; set; }
    public UploadFile Thumbnail { get; set; }
    public long ThumbnailId { get; set; }
    public ICollection<Game> Games { get; set; }

    protected Publisher()
    {
        
    }
    public Publisher(string name, string description, string slug, string metaDescription, string keyWords,
        string websiteUrl, string wikipediaUrl, float rating,UploadFile thumbnail, long userId) : base(userId, true)
    {
        Name = name;
        Description = description;
        Slug = slug;
        MetaDescription = metaDescription;
        KeyWords = keyWords;
        WebsiteUrl = websiteUrl;
        WikipediaUrl = wikipediaUrl;
        Rating = rating;
        Thumbnail = thumbnail;
    }
}