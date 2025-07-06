using Microsoft.EntityFrameworkCore;
using RetroRemedy.Core.Entities.LabelEntities;
using RetroRemedy.Infrastructure.Common;

namespace RetroRemedy.Infrastructure.Repositories;

public class CategoryRepository(RetroContext dbContext):BaseRepository<Category>(dbContext),ICategoryRepository
{
    private readonly RetroContext _context = dbContext;

    public async Task<bool> IsCategoryDuplicate(string nameLower, string slug,long exclusionId = 0)
        => await dbContext.Categories.AsNoTracking()
            .AnyAsync(x=>x.IsRemoved &&  x.Name.ToLower().Equals(nameLower) && x.Slug == slug && x.Id != exclusionId);

}