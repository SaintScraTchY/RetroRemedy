using RetroRemedy.Core.Common;

namespace RetroRemedy.Core.Entities.GameCategories;

public interface IPublisherRepository : IBaseRepository<Publisher>
{
    Task<bool> IsPublisherDuplicate(string nameLower, long excludeId = 0);
}