using RetroRemedy.Core.Entities.BlogPosts;
using RetroRemedy.Core.Entities.Games;

namespace RetroRemedy.Core.Entities.Tags;

public class Tag : BaseEntity
{
    public string Name { get; set; }
    public string Slug { get; set; }
    public string MetaDescription { get; set; }
    public string KeyWords { get; set; }
    public ICollection<Game> Games { get; set; }
    public ICollection<BlogPost> BlogPosts { get; set; }

    protected Tag(string name, string slug, string metaDescription, string keyWords, 
        long userId) : base(userId, true)
    {
        Name = name;
        Slug = slug;
        MetaDescription = metaDescription;
        KeyWords = keyWords;
    }
}