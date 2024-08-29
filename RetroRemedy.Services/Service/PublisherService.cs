using AutoMapper;
using ErrorOr;
using RetroRemedy.Common.Contracts.PublisherContracts;
using RetroRemedy.Core.Common;
using RetroRemedy.Core.Entities.Publishers;
using RetroRemedy.Core.Entities.Tags;
using RetroRemedy.Core.Enums;
using RetroRemedy.Services.IService;

namespace RetroRemedy.Services.Service;

public class PublisherService : IPublisherService
{
    private readonly IPublisherRepository _publisherRepository;
    private readonly IUploadFileService _fileService;
    private readonly IMapper _mapper;

    public PublisherService(IPublisherRepository publisherRepository, IMapper mapper)
    {
        _publisherRepository = publisherRepository;
        _mapper = mapper;
    }

    public async Task<ErrorOr<Created>> CreatePublisher(CreatePublisherModel model, long userId)
    {
        if (await _publisherRepository.IsPublisherDuplicate(model.Name.ToLower()))
        {
            return Error.Conflict();
        }

        var thumbnail = await _fileService.SaveFileLocal(model.ThumbnailModel);

        if (thumbnail.IsError)
        {
            return thumbnail.Errors;
        }

        var publisher = new Publisher(model.Name, model.Description,model.Slug,model.MeteDescription,
            model.KeyWords,model.WebsiteUrl ,model.WikipediaUrl,thumbnail.Value,userId);
        
        
        await _publisherRepository.CreateAsync(publisher);
        if (await _publisherRepository.SaveChangesAsync())
        {
            return Result.Created;
        }

        return Error.Failure();
    }

    public async Task<ErrorOr<Updated>> UpdatePublisher(UpdatePublisherModel model, long userId)
    {
        if (await _publisherRepository.IsPublisherDuplicate(model.Name.ToLower(),model.Id))
        {
            return Error.Conflict();
        }

        var publisher = await _publisherRepository.GetByIdAsync(model.Id);
        long oldThumbnailId = publisher.ThumbnailId;
        
        if (model.ThumbnailModel != null)
        {
            var newThumbnail = await _fileService.SaveAndCreateUploadFile(model.ThumbnailModel);
            if (newThumbnail.IsError)
            {
                return newThumbnail.Errors;
            }

            publisher.SetThumbnail(newThumbnail.Value.Id);
        }
        
        publisher.Update(model.Name, model.Description,model.Slug,model.MeteDescription,
            model.KeyWords,model.WebsiteUrl ,model.WikipediaUrl,userId);
        
        _publisherRepository.UpdateAsync(publisher);
        if (await _publisherRepository.SaveChangesAsync())
        {
            if (oldThumbnailId != publisher.ThumbnailId)
            {
                _fileService.RemoveFile(oldThumbnailId);
            }
            return Result.Updated;
        }

        return Error.Failure();
    }

    public async Task<ErrorOr<Deleted>> RemovePublisherBy(long Id, long userId)
    {
        var publisher = await _publisherRepository.GetByIdAsync(Id);
        
        publisher.Remove(userId);
        _publisherRepository.UpdateAsync(publisher);
        if (await _publisherRepository.SaveChangesAsync())
        {
            return Result.Deleted;
        }
        
        return Error.Failure();
    }

    public Task<ErrorOr<UpdatePublisherModel>> GetPublisherDetailBy(long Id)
    {
        throw new NotImplementedException();
    }

    public Task<ErrorOr<PaginatedResult<PublisherViewModel>>> GetPublisherAdminListBy()
    {
        throw new NotImplementedException();
    }
}