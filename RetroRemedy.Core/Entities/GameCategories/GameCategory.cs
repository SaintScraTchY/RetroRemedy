using RetroRemedy.Core.Entities.Games;
using RetroRemedy.Core.Entities.Tags;

namespace RetroRemedy.Core.Entities.GameCategories;

public class GameCategory : BasicEntity
{
    public long GameId { get; private set; }
    public Game Game { get; private set; }
    public long TagId { get; private set; }
    public Tag Tag { get; private set; }

    public GameCategory(long gameId, long tagId)
    {
        GameId = gameId;
        TagId = tagId;
    }
}