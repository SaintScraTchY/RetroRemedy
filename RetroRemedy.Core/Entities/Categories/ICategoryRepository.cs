using RetroRemedy.Core.Common;

namespace RetroRemedy.Core.Entities.Categories;

public interface ICategoryRepository : IBaseRepository<Category>
{
    Task<bool> IsCategoryDuplicate(string nameLower, string slug,long exclusionId = 0);
}