using ErrorOr;
using RetroRemedy.Common.Contracts;
using RetroRemedy.Common.Contracts.GameContracts;

namespace RetroRemedy.Services.IService;

public interface IGameService
{
    Task<ErrorOr<Created>> CreateGame(CreateGameModel model,long userId);
    Task<ErrorOr<Updated>> UpdateGame(UpdateGameModel model,long userId);
    Task<ErrorOr<Deleted>> RemoveGameBy(long Id,long userId);
    Task<ErrorOr<GameDetailViewModel>> GetGameDetailBy(long Id);
    Task<ErrorOr<PaginatedResult<GameViewModel>>> GetGameAdminListBy(SearchGameModel searchModel);
    Task<ErrorOr<PaginatedResult<GameQueryViewModel>>> GetGameListBy(SearchGameModel searchModel);
}