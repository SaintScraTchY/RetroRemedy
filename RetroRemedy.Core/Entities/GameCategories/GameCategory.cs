using RetroRemedy.Core.Common;
using RetroRemedy.Core.Entities.Categories;
using RetroRemedy.Core.Entities.Games;
using RetroRemedy.Core.Entities.Tags;

namespace RetroRemedy.Core.Entities.GameCategories;

public class GameCategory : BasicEntity
{
    public long GameId { get; private set; }
    public Game Game { get; private set; }
    public long CategoryId { get; private set; }
    public Category Category { get; private set; }

    protected GameCategory()
    {
        
    }
    public GameCategory(long gameId, long categoryId)
    {
        GameId = gameId;
        CategoryId = categoryId;
    }
}