using RetroRemedy.Core.Entities.BlogPosts;
using RetroRemedy.Core.Entities.Games;
using RetroRemedy.Core.Entities.Ratings;

namespace RetroRemedy.Core.Entities.Categories;

public class Category : BaseEntity,IRatingRepository
{
    public string Name { get; private set; }
    public string? Description { get; private set; }
    public string Slug { get; private set; }
    public string MetaDescription { get; private set; }
    public string KeyWords { get; private set; }
    
    public long ParentId { get; private set; }
    public Category Parent { get; set; }
    public ICollection<Game> Games { get; set; }
    public ICollection<BlogPost> BlogPosts { get; set; }

    protected Category(long userId) : base(userId, true)
    {
    }

    public int i { get; set; }
}