using Microsoft.AspNetCore.Identity;
using RetroRemedy.Core.Entities.BlogEntities;

namespace RetroRemedy.Core.Entities.AppUsers;

public class AppUser : IdentityUser<long>
{
    public ICollection<IdentityRole> Roles { get; set; }
    //public ICollection<Comment> Comments { get; set; }
    public ICollection<BlogPost> BlogPosts { get; set; }

}