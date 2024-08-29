using RetroRemedy.Core.Common;

namespace RetroRemedy.Core.Entities.Tags;

public interface ITagRepository : IBaseRepository<Tag>
{
    Task<bool> IsTagDuplicate(string nameLower,long excludeId = 0);

}