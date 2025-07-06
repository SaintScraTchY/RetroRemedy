using Microsoft.EntityFrameworkCore;
using RetroRemedy.Core.Entities.BlogEntities;
using RetroRemedy.Infrastructure.Common;

namespace RetroRemedy.Infrastructure.Repositories;

public class BlogPostTagRepository(RetroContext dbContext):BaseRepository<BlogPostTag>(dbContext),IBlogPostTagRepository
{
    private readonly RetroContext _context = dbContext;

}