using Microsoft.EntityFrameworkCore;
using RetroRemedy.Core.Entities.Publishers;
using RetroRemedy.Infrastructure.Common;

namespace RetroRemedy.Infrastructure.Repositories;

public class PublisherRepository(RetroContext context) : BaseRepository<Publisher>(context),IPublisherRepository
{
    private readonly RetroContext _context = context;
    
    public async Task<bool> IsPublisherDuplicate(string nameLower, long excludeId = 0)
        => await _context.Set<Publisher>().AsNoTracking().AnyAsync(x => !x.IsRemoved && x.Name.ToLower().Equals(nameLower) && x.Id != excludeId);
}