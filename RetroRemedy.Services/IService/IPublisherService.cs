using ErrorOr;
using RetroRemedy.Common.Contracts.PublisherContracts;
using RetroRemedy.Core.Common;

namespace RetroRemedy.Services.IService;

public interface IPublisherService
{
    Task<ErrorOr<Created>> CreatePublisher(CreatePublisherModel model,long userId);
    Task<ErrorOr<Updated>> UpdatePublisher(UpdatePublisherModel model,long userId);
    Task<ErrorOr<Deleted>> RemovePublisherBy(long Id,long userId);
    Task<ErrorOr<UpdatePublisherModel>> GetPublisherDetailBy(long Id);
    Task<ErrorOr<PaginatedResult<PublisherViewModel>>> GetPublisherAdminListBy();
}