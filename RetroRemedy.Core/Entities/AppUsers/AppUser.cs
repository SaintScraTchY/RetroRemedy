using Microsoft.AspNetCore.Identity;
using RetroRemedy.Core.Entities.BlogPosts;
using RetroRemedy.Core.Entities.Comments;

namespace RetroRemedy.Core.Entities.AppUsers;

public class AppUser : IdentityUser<long>
{
    public ICollection<IdentityRole> Roles { get; set; }
    public ICollection<Comment> Comments { get; set; }
    public ICollection<BlogPost> BlogPosts { get; set; }

}