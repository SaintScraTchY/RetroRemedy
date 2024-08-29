using RetroRemedy.Core.Common;

namespace RetroRemedy.Core.Entities.Publishers;

public interface IPublisherRepository : IBaseRepository<Publisher>
{
    Task<bool> IsPublisherDuplicate(string nameLower, long excludeId = 0);
}