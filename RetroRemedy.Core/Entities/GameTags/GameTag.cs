using RetroRemedy.Core.Common;
using RetroRemedy.Core.Entities.Games;
using RetroRemedy.Core.Entities.Tags;

namespace RetroRemedy.Core.Entities.GameTags;

public class GameTag : BasicEntity
{
    public long GameId { get; private set; }
    public Game Game { get; private set; }
    public long TagId { get; private set; }
    public Tag Tag { get; private set; }

    protected GameTag()
    {
        
    }
    public GameTag(Game game, long tagId)
    {
        Game = game;
        TagId = tagId;
    }
    
    public GameTag(long gameId, long tagId)
    {
        GameId = gameId;
        TagId = tagId;
    }
}