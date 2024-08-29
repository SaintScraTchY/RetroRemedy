using ErrorOr;
using RetroRemedy.Common.Contracts;
using RetroRemedy.Common.Contracts.TagContracts;
using RetroRemedy.Core.Common;

namespace RetroRemedy.Services.IService;

public interface ITagService
{
    Task<ErrorOr<Created>> CreateTag(CreateTagModel model,long userId);
    Task<ErrorOr<Updated>> UpdateTag(UpdateTagModel model,long userId);
    Task<ErrorOr<Deleted>> RemoveTagBy(long Id,long userId);
    Task<ErrorOr<UpdateTagModel>> GetTagDetailBy(long Id);
    Task<ErrorOr<PaginatedResult<TagViewModel>>> GetTagAdminListBy(SearchTagModel searchModel);
    Task<ErrorOr<IEnumerable<TagQueryViewModel>>> GetTagListBy();
}