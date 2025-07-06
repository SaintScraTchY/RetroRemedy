using RetroRemedy.Common.Contracts.GameContracts;
using RetroRemedy.Core.Entities.GameCategories;

namespace RetroRemedy.Common.MapperProfiles;

public partial class GameMapper
{
    public partial UpdateGameModel MapUpdateGameModel(Game game);
}