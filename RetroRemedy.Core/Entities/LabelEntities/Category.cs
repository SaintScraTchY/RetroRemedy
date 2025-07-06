using RetroRemedy.Core.Common;
using RetroRemedy.Core.Entities.BlogEntities;
using RetroRemedy.Core.Entities.UploadMedias;

namespace RetroRemedy.Core.Entities.LabelEntities;

public class Category : BasicEntity
{
    public string Name { get; private set; }
    public string? Description { get; private set; }
    public string Slug { get; private set; }
    public string MetaDescription { get; private set; }
    public string KeyWords { get; private set; }
    
    public long? ParentId { get; private set; }
    public Category? Parent { get; set; }

    public long IconId { get; private set; }
    public UploadFile Icon { get; set; }
    public ICollection<GameCategory> GameCategories { get; set; }
    public ICollection<BlogPost> BlogPosts { get; set; }

    protected Category(long iconId)
    {
        IconId = iconId;
    }

    public Category(string name, string? description, string slug, string metaDescription,
        string keyWords, long? parentId, UploadFile icon)
    {
        Name = name;
        Description = description;
        Slug = slug.ToLower();
        MetaDescription = metaDescription;
        KeyWords = keyWords;
        Icon = icon;
        ParentId = parentId ?? null;
    }

    public void ChangeIcon(long iconId)
    {
        IconId = iconId;
    }
    
    public void Update(string name, string? description, string slug, string metaDescription,
        string keyWords, long? parentId)
    {
        Name = name;
        Description = description;
        Slug = slug;
        MetaDescription = metaDescription;
        KeyWords = keyWords;
        ParentId = parentId ?? ParentId;
    }
}