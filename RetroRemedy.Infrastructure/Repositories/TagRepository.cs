using Microsoft.EntityFrameworkCore;
using RetroRemedy.Core.Entities.Tags;
using RetroRemedy.Infrastructure.Common;

namespace RetroRemedy.Infrastructure.Repositories;

public class TagRepository(DbContext dbContext) : BaseRepository<Tag>(dbContext) ,ITagRepository
{
    private readonly DbContext _context = dbContext;
}