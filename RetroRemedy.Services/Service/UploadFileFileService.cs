using ErrorOr;
using RetroRemedy.Common.Contracts;
using RetroRemedy.Common.Helpers;
using RetroRemedy.Core.Entities.UploadMedias;
using RetroRemedy.Core.Enums;
using RetroRemedy.Services.IService;

namespace RetroRemedy.Services.Service;

public class UploadFileService(
    IUploadFileRepository _uploadFileRepository,
    IValidatorService Validator)
    : IUploadFileService
{
    private const uint maxFileSize = 1024 * 1024 * 4;
    public async Task<ErrorOr<UploadFile>> SaveFileLocal(UploadFileModel uploadFile)
    {
        // Validate the upload file model
        var validationResult = await Validator.ValidateAsync(uploadFile);
        if (!validationResult.IsError)
        {
            return validationResult.Errors;
        }

        // Generate unique filename and file path
        var uniqueFileName = GenerateUniqueFileName(uploadFile.File.Name);
        var filePath = Path.Combine(AppConst.RootPath, "uploads", uniqueFileName);
        var fileWebUrl = $"/uploads/{uniqueFileName}";
        try
        {
            // Save the file to the local file system
            await using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await uploadFile.File.OpenReadStream(maxFileSize).CopyToAsync(fileStream);
            }

            // Create UploadFile entity without saving to the database

            var uploadFileEntity = new UploadFile(uploadFile.Value, uploadFile.Caption,uploadFile.Order, MediaType.Picture, fileWebUrl,
                filePath);

            return uploadFileEntity;
        }
        catch (Exception ex)
        {
            // Handle exceptions and return a proper error
            return Error.Failure("FileSaveError", ex.Message);
        }
    }

    public async Task<ErrorOr<List<UploadFile>>> SaveFilesLocal(IEnumerable<UploadFileModel> uploadFiles)
    {
        var uploadFileEntities = new List<UploadFile>();

        foreach (var uploadFile in uploadFiles)
        {
            var fileSaveResult = await SaveFileLocal(uploadFile);
            if (fileSaveResult.IsError)
            {
                return fileSaveResult.Errors; // Return the errors if any file save fails
            }

            uploadFileEntities.Add(fileSaveResult.Value);
        }

        return uploadFileEntities;
    }

    public async Task<ErrorOr<Success>> UpdateFile(UploadFileModel uploadModel)
    {
        // Validation logic for updating files
        var validationResult = await Validator.ValidateAsync(uploadModel);
        if (!validationResult.IsError)
        {
            return validationResult.Errors;
        }

        // Get the existing file entity
        var existingFile = await _uploadFileRepository.GetByIdAsync(uploadModel.Key);
        if (existingFile == null)
        {
            return Error.NotFound("FileNotFound", "The file does not exist.");
        }

        // Update fields if they are provided
        
        existingFile.Update(uploadModel.Value,uploadModel.Caption,uploadModel.Order);
        
        // Update the file if a new one is uploaded
        if (uploadModel.File != null)
        {
            var fileSaveResult = await SaveFileLocal(uploadModel);
            if (fileSaveResult.IsError)
            {
                return fileSaveResult.Errors;
            }
        }

        _uploadFileRepository.UpdateAsync(existingFile);
        if (await _uploadFileRepository.SaveChangesAsync())
        {
            return Result.Success;
        }
        return Error.Failure();
    }

    public async Task<ErrorOr<Success>> UpdateFiles(IEnumerable<UploadFileModel> uploadModels)
    {
        foreach (var uploadModel in uploadModels)
        {
            var updateResult = await UpdateFile(uploadModel);
            if (updateResult.IsError)
            {
                return updateResult.Errors;
            }
            //TODO Implement Better Range Update Files Method
            //_uploadFileRepository.UpdateRangeAsync();
        }
        
        if (await _uploadFileRepository.SaveChangesAsync())
        {
            return Result.Success;
        }
        return Error.Failure();
    }

    public async Task<ErrorOr<UploadFile>> SaveAndCreateUploadFile(UploadFileModel uploadModel, long entityId = 0,
        UploadType type = UploadType.None)
    {
        var saveFileResult = await SaveFileLocal(uploadModel);
        if (saveFileResult.IsError)
        {
            return saveFileResult.Errors;
        }

        //TODO refactor This
        switch (type)
        {
            case UploadType.Game:
                saveFileResult.Value.GameId = entityId;
                break;
            case UploadType.BlogPost:
                saveFileResult.Value.BlogPostId = entityId;
                break;
            case UploadType.None:
                break;
            default:
                break;
        }

        var entity = await _uploadFileRepository.CreateAsync(saveFileResult.Value);
        if (await _uploadFileRepository.SaveChangesAsync())
        {
            return entity;
        }

        return Error.Failure();
    }

    public async Task<ErrorOr<Success>> SaveAndCreateUploadFiles(IEnumerable<UploadFileModel> uploadModels,long entityId,UploadType type)
    {
        var saveFileResults = await SaveFilesLocal(uploadModels);
        if (saveFileResults.IsError)
        {
            return saveFileResults.Errors;
        }
        
        //TODO refactor This
        switch (type)
        {
            case UploadType.Game:
                foreach (var uploadFile in saveFileResults.Value)
                {
                    uploadFile.GameId = entityId;
                }
                break;
            case UploadType.BlogPost:
                foreach (var uploadFile in saveFileResults.Value)
                {
                    uploadFile.BlogPostId = entityId;
                }
                break;
            case UploadType.None:
            default:
                break;
        }

        await _uploadFileRepository.CreateManyAsync(saveFileResults.Value);
        if (await _uploadFileRepository.SaveChangesAsync())
        {
            return Result.Success;
        }

        return Error.Failure();
    }

    public void RemoveFileLocal(string filePath)
    {
        if (File.Exists(filePath))
        {
            File.Delete(filePath);
        }
    }

    public void RemoveFilesLocal(IEnumerable<string> filePaths)
    {
        foreach (var path in filePaths)
        {
            if (File.Exists(path))
            {
                File.Delete(path);
            }
        }
    }

    public async Task<ErrorOr<Success>> RemoveFile(long id)
    {
        var existingFile = await _uploadFileRepository.GetByIdAsync(id);
        if (existingFile == null)
        {
            return Error.NotFound("FileNotFound", "The file does not exist.");
        }

        // Delete the file from the local file system
        RemoveFileLocal(existingFile.FilePath);
        
        existingFile.Remove();

        _uploadFileRepository.UpdateAsync(existingFile);
        if (await _uploadFileRepository.SaveChangesAsync())
        {
            return Result.Success;
        }

        return Error.Failure();
    }

    public async Task<ErrorOr<Success>> RemoveFiles(IEnumerable<long> ids)
    {
        foreach (var id in ids)
        {
            var result = await RemoveFile(id);
            if (result.IsError)
            {
                return result.Errors;
            }
        }

        return Result.Success;
    }

    // Helper method to generate unique file names
    private static string GenerateUniqueFileName(string fileName)
    {
        return $"{Guid.NewGuid()}_{Path.GetFileName(fileName)}";
    }
}
