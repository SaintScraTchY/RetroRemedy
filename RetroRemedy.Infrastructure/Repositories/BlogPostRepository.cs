using Microsoft.EntityFrameworkCore;
using RetroRemedy.Core.Entities.BlogEntities;
using RetroRemedy.Infrastructure.Common;

namespace RetroRemedy.Infrastructure.Repositories;

public class BlogPostRepository(RetroContext dbContext):BaseRepository<BlogPost>(dbContext),IBlogPostRepository
{
    private readonly RetroContext _context = dbContext;

}