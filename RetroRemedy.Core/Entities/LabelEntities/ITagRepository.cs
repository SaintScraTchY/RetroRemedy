using RetroRemedy.Core.Common;

namespace RetroRemedy.Core.Entities.LabelEntities;

public interface ITagRepository : IBaseRepository<Tag>
{
    Task<bool> IsTagDuplicate(string nameLower,long excludeId = 0);

}