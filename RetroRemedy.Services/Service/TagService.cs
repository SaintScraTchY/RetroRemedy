using AutoMapper;
using ErrorOr;
using RetroRemedy.Common.Contracts.TagContracts;
using RetroRemedy.Core.Common;
using RetroRemedy.Core.Entities.LabelEntities;
using RetroRemedy.Services.IService;

namespace RetroRemedy.Services.Service;

public class TagService : ITagService
{
    private readonly ITagRepository _tagRepository;
    private readonly IMapper _mapper;

    public TagService(ITagRepository tagRepository, IMapper mapper)
    {
        _tagRepository = tagRepository;
        _mapper = mapper;
    }

    public async Task<ErrorOr<Created>> CreateTag(CreateTagModel model, long userId)
    {
        if (await _tagRepository.IsTagDuplicate(model.Name.ToLower()))
        {
            return Error.Conflict();
        }

        var tag = new Tag(model.Name, userId);
        await _tagRepository.CreateAsync(tag);
        if (await _tagRepository.SaveChangesAsync())
        {
            return Result.Created;
        }

        return Error.Failure();
    }

    public async Task<ErrorOr<Updated>> UpdateTag(UpdateTagModel model, long userId)
    {
        if (await _tagRepository.IsTagDuplicate(model.Name.ToLower(),model.Id))
        {
            return Error.Conflict();
        }

        var tag = await _tagRepository.GetByIdAsync(model.Id);
        tag.Update(model.Name,userId);
        _tagRepository.UpdateAsync(tag);
        if (await _tagRepository.SaveChangesAsync())
        {
            return Result.Updated;
        }

        return Error.Failure();
    }

    public async Task<ErrorOr<Deleted>> RemoveTagBy(long Id, long userId)
    {
        var tag = await _tagRepository.GetByIdAsync(Id);
        tag.Remove(userId);
        _tagRepository.UpdateAsync(tag);
        if (await _tagRepository.SaveChangesAsync())
        {
            return Result.Deleted;
        }

        return Error.Failure();
    }

    public async Task<ErrorOr<UpdateTagModel>> GetTagDetailBy(long Id)
    {
        var tag = await _tagRepository.GetByIdAsync(Id);
        return _mapper.Map<UpdateTagModel>(tag);
    }

    public async Task<ErrorOr<PaginatedResult<TagViewModel>>> GetTagAdminListBy(SearchTagModel searchModel)
    {
        var tags = await _tagRepository.GetAllAsync();
        return new PaginatedResult<TagViewModel>(1, 50, 50, _mapper.Map<IEnumerable<TagViewModel>>(tags));
    }

    public Task<ErrorOr<IEnumerable<TagQueryViewModel>>> GetTagListBy()
    {
        throw new NotImplementedException();
    }
}