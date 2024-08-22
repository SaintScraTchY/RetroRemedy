using RetroRemedy.Core.Common;
using RetroRemedy.Core.Entities.BlogPostTags;
using RetroRemedy.Core.Entities.GameTags;

namespace RetroRemedy.Core.Entities.Tags;

public class Tag : BaseEntity
{
    public string Name { get; set; }
    public ICollection<GameTag> GameTags { get; set; }
    public ICollection<BlogPostTag> BlogPostTags { get; set; }

    protected Tag()
    {
        
    }
    public Tag(string name, long userId) : base(userId, true)
    {
        Name = name;
    }
}