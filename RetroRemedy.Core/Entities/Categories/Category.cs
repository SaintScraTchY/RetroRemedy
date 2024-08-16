using RetroRemedy.Core.Common;
using RetroRemedy.Core.Entities.BlogPostCategories;
using RetroRemedy.Core.Entities.GameCategories;
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
    public ICollection<GameCategory> GameCategories { get; set; }
    public ICollection<BlogPostCategory> BlogPostCategories { get; set; }

    protected Category(long userId) : base(userId, true)
    {
    }

    public int i { get; set; }
}