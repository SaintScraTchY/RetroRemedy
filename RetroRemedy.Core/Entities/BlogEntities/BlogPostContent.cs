using RetroRemedy.Core.Common;
using RetroRemedy.Core.Enums;

namespace RetroRemedy.Core.Entities.BlogEntities;

public class BlogPostContent : BaseEntity
{
    public string? DraftContent { get; set; }
    public string? DraftContentRaw { get; set; }
    
    public string? PublishedContent { get; set; }
    public string? PublishedContentRaw { get; set; }

    public ContentLanguage Language { get; set; }

    public long BlogPostId { get; set; }
    public BlogPost BlogPost { get; set; }
}