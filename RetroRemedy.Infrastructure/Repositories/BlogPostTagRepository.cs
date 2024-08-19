using Microsoft.EntityFrameworkCore;
using RetroRemedy.Core.Entities.BlogPostTags;
using RetroRemedy.Infrastructure.Common;

namespace RetroRemedy.Infrastructure.Repositories;

public class BlogPostTagRepository(DbContext dbContext):BaseRepository<BlogPostTag>(dbContext),IBlogPostTagRepository
{
    private readonly DbContext _context = dbContext;

}