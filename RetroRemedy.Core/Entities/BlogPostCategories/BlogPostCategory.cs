using RetroRemedy.Core.Common;
using RetroRemedy.Core.Entities.BlogPosts;
using RetroRemedy.Core.Entities.Categories;

namespace RetroRemedy.Core.Entities.BlogPostCategories;

public class BlogPostCategory : BasicEntity
{
    public long BlogPostId { get; set; }
    public BlogPost BlogPost { get; set; }

    public long CategoryId { get; set; }
    public Category Category { get; set; }

    protected BlogPostCategory()
    {
        
    }
    public BlogPostCategory(long blogPostId, long categoryId)
    {
        BlogPostId = blogPostId;
        CategoryId = categoryId;
    }
}