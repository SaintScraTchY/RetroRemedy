using Microsoft.EntityFrameworkCore;
using RetroRemedy.Core.Entities.BlogPosts;
using RetroRemedy.Infrastructure.Common;

namespace RetroRemedy.Infrastructure.Repositories;

public class BlogPostRepository(DbContext dbContext):BaseRepository<BlogPost>(dbContext),IBlogPostRepository
{
    private readonly DbContext _context = dbContext;

}