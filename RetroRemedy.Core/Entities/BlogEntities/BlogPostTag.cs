using RetroRemedy.Core.Common;
using RetroRemedy.Core.Entities.LabelEntities;

namespace RetroRemedy.Core.Entities.BlogEntities;

public class BlogPostTag : BasicEntity
{
    public long BlogPostId { get; private set; }
    public BlogPost BlogPost { get; private set; }
    public long TagId { get; private set; }
    public Tag Tag { get; private set; }

    protected BlogPostTag()
    {
        
    }

    public BlogPostTag(long blogPostId, long tagId)
    {
        BlogPostId = blogPostId;
        TagId = tagId;
    }
}