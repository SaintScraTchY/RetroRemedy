using RetroRemedy.Core.Common;
using RetroRemedy.Core.Entities.AppUsers;
using RetroRemedy.Core.Entities.BlogPosts;

namespace RetroRemedy.Core.Entities.Comments;

public class Comment : BaseEntity
{
    public string Content { get; set; }
    public long AuthorId { get; set; }
    public AppUser Author { get; set; }
    public long BlogPostId { get; set; }
    public BlogPost BlogPost { get; set; }
    public long? ParentCommentId { get; set; }
    public Comment? ParentComment { get; set; }
    public bool IsBlogPostAuthor { get; set; }
    public bool IsAdmin { get; set; }

    protected Comment()
    {
        
    }
    
    public Comment(string content, long authorId, long blogPostId, long? parentCommentId,
        bool isBlogPostAuthor, bool isAdmin, long userId, bool isActive = false) 
        : base(userId,(isAdmin || isBlogPostAuthor))
    {
        Content = content;
        AuthorId = authorId;
        BlogPostId = blogPostId;
        ParentCommentId = parentCommentId;
        IsBlogPostAuthor = isBlogPostAuthor;
        IsAdmin = isAdmin;
    }
}