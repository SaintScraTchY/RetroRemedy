using AutoMapper;
using ErrorOr;
using RetroRemedy.Common.Contracts.GameContracts;
using RetroRemedy.Common.Helpers;
using RetroRemedy.Core.Common;
using RetroRemedy.Core.Entities.GameCategories;
using RetroRemedy.Core.Enums;
using RetroRemedy.Services.IService;

namespace RetroRemedy.Services.Service;

public class GameService(IValidatorService validatorService, IGameRepository gameRepository, IUploadFileService fileService)
    : IGameService
{
    public async Task<ErrorOr<Created>> CreateGame(CreateGameModel model,long userId)
    {
        var validationResult = await validatorService.ValidateAsync(model);
        
        if (validationResult.IsError)
        {
            return validationResult.Errors;
        }

        var fileResult = await fileService.SaveFileLocal(model.ThumbnailFile);
        
        if (fileResult.IsError)
            return fileResult.Errors;

        var listFilesResult = await fileService.SaveFilesLocal(model.Files);
        
        if (listFilesResult.IsError)
            return fileResult.Errors;

        var game = new Game(model.Title, model.Description, model.ReleaseDate
            , model.PublisherId, fileResult.Value, model.tagIds, listFilesResult.Value, userId);

        await gameRepository.CreateAsync(game);

        if (await gameRepository.SaveChangesAsync())
        {
            return Result.Created;
        }
        return Error.Failure(description: AppConst.Error_CreateFailed);
    }

    public async Task<ErrorOr<Updated>> UpdateGame(UpdateGameModel model,long userId)
    {
        var validationResult = await validatorService.ValidateAsync(model);
        
        if (validationResult.IsError)
        {
            return validationResult.Errors;
        }

        var game = await gameRepository.GetByIdAsync(model.Id);

        if (model.Files.Any(x => x.IsAdded))
        {
            await fileService.SaveAndCreateUploadFiles(model.Files.Where(x => x.IsAdded).ToList(),game.Id,UploadType.Game);
        }

        if (model.Files.Any(x=>x.IsDeleted))
        {
            await fileService
                .RemoveFiles(model.Files
                    .Where(x => x.IsDeleted)
                    .Select(x=>x.Key)
                    .ToList());
        }

        long? thumbnailId = null;
        if (model.ThumbnailFile != null)
        {
            var fileResult = await fileService.SaveAndCreateUploadFile(model.ThumbnailFile,game.Id,UploadType.Game);
                
            if (fileResult.IsError)
                return fileResult.Errors;

            thumbnailId = fileResult.Value.Id;
        }
        
        game.Update(model.Title, model.Description, model.ReleaseDate
            , model.PublisherId,thumbnailId,userId);

        gameRepository.UpdateAsync(game);

        if (await gameRepository.SaveChangesAsync())
        {
            return Result.Updated;
        }
        return Error.Failure(description: AppConst.Error_CreateFailed);
    }

    public async Task<ErrorOr<Deleted>> RemoveGameBy(long id,long userId)
    {
        var game = await gameRepository.GetByIdAsync(id);
        game.Remove(userId);
        gameRepository.UpdateAsync(game);
        if (await gameRepository.SaveChangesAsync())
        {
            return Result.Deleted;
        }

        return Error.Failure();
    }

    public async Task<ErrorOr<UpdateGameModel>> GetGameDetailBy(long id)
    {
        return mapper.Map<UpdateGameModel>(  await gameRepository.GetByIdAsync(id));
    }

    public async Task<ErrorOr<PaginatedResult<GameViewModel>>> GetGameAdminListBy(SearchGameModel searchModel)
    {
        return new PaginatedResult<GameViewModel>(1, 50, 50,
            mapper.Map<IEnumerable<GameViewModel>>(await gameRepository.GetAllAsync()));
    }

    public Task<ErrorOr<PaginatedResult<GameQueryViewModel>>> GetGameListBy(SearchGameModel searchModel)
    {
        throw new NotImplementedException();
    }
}