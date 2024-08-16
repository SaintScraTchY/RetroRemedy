using RetroRemedy.Core.Common;
using RetroRemedy.Core.Entities.Games;
using RetroRemedy.Core.Entities.Tags;

namespace RetroRemedy.Core.Entities.GameTags;

public class GameTag : BasicEntity
{
    public long GameId { get; set; }
    public Game Game { get; set; }
    public long TagId { get; set; }
    public Tag Tag { get; set; }

    public GameTag(long gameId, long tagId)
    {
        GameId = gameId;
        TagId = tagId;
    }
}