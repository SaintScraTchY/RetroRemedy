using Microsoft.EntityFrameworkCore;
using RetroRemedy.Core.Entities.Tags;
using RetroRemedy.Infrastructure.Common;

namespace RetroRemedy.Infrastructure.Repositories;

public class TagRepository(RetroContext dbContext) : BaseRepository<Tag>(dbContext) ,ITagRepository
{
    private readonly RetroContext _context = dbContext;
}