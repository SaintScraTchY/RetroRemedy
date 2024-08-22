using RetroRemedy.Core.Common;
using RetroRemedy.Core.Entities.BlogPostCategories;
using RetroRemedy.Core.Entities.BlogPosts;
using RetroRemedy.Core.Entities.GameCategories;
using RetroRemedy.Core.Entities.Ratings;

namespace RetroRemedy.Core.Entities.Categories;

public class Category : BaseEntity
{
    public string Name { get; private set; }
    public string? Description { get; private set; }
    public string Slug { get; private set; }
    public string MetaDescription { get; private set; }
    public string KeyWords { get; private set; }
    
    public long? ParentId { get; private set; }
    public Category? Parent { get; set; }
    public ICollection<GameCategory> GameCategories { get; set; }
    public ICollection<BlogPost> BlogPosts { get; set; }

    protected Category()
    {
        
    }

    public Category(string name, string? description, string slug, string metaDescription,
        string keyWords, long? parentId, long userId, bool isActive = false) : base(userId, isActive)
    {
        Name = name;
        Description = description;
        Slug = slug;
        MetaDescription = metaDescription;
        KeyWords = keyWords;
        ParentId = parentId ?? null;
    }
}