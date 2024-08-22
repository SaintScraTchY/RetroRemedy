using ErrorOr;
using RetroRemedy.Common.Contracts;
using RetroRemedy.Core.Entities.UploadMedias;

namespace RetroRemedy.Services.IService;

public interface IUploadFileService
{
    Task<ErrorOr<UploadFile>> SaveFileLocal(UploadFileModel uploadFile);
    Task<ErrorOr<List<UploadFile>>> SaveFilesLocal(IEnumerable<UploadFileModel> uploadFiles);
    Task<ErrorOr<Success>> UpdateFile(UploadFileModel uploadModel);
    Task<ErrorOr<Success>> UpdateFiles(IEnumerable<UploadFileModel> uploadModels);
    Task<ErrorOr<UploadFile>> SaveAndCreateUploadFile(UploadFileModel uploadModel);
    Task<ErrorOr<Success>> SaveAndCreateUploadFiles(IEnumerable<UploadFileModel> uploadModels);
    Task<ErrorOr<Success>> RemoveFile(long id);
    Task<ErrorOr<Success>> RemoveFiles(IEnumerable<long> ids);
}