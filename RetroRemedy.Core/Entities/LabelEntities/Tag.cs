using RetroRemedy.Core.Common;
using RetroRemedy.Core.Entities.BlogEntities;

namespace RetroRemedy.Core.Entities.LabelEntities;

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
    
    public void Update(string name, long userId)
    {
        base.UpdateTimestamp(userId);
        Name = name;
    }
}