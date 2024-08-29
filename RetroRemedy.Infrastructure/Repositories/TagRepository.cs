using Microsoft.EntityFrameworkCore;
using RetroRemedy.Core.Entities.Tags;
using RetroRemedy.Infrastructure.Common;

namespace RetroRemedy.Infrastructure.Repositories;

public class TagRepository(RetroContext dbContext) : BaseRepository<Tag>(dbContext) ,ITagRepository
{
    private readonly RetroContext _context = dbContext;
    public async Task<bool> IsTagDuplicate(string nameLower,long excludeId = 0)
        => await _context.Set<Tag>().AsNoTracking().AnyAsync(x => !x.IsRemoved && x.Name.ToLower().Equals(nameLower) && x.Id != excludeId);
}