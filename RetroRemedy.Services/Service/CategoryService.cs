using AutoMapper;
using ErrorOr;
using RetroRemedy.Common.Contracts.CategoryContracts;
using RetroRemedy.Core.Common;
using RetroRemedy.Core.Entities.Categories;
using RetroRemedy.Services.IService;

namespace RetroRemedy.Services.Service;

public class CategoryService(ICategoryRepository categoryRepository, IMapper mapper, IUploadFileService fileService)
    : ICategoryService
{
    // private readonly ICategoryRepository _categoryRepository = categoryRepository;
    // private readonly IMapper _mapper = mapper;
    // private readonly IUploadFileService _fileService = fileService;

    public async Task<ErrorOr<Created>> CreateCategory(CreateCategoryModel model, long userId)
    {
        if (await categoryRepository.IsCategoryDuplicate(model.Name.ToLower(), model.Slug.ToLower()))
        {
            return Error.Conflict();
        }
        
        var uploadFile = await fileService.SaveFileLocal(model.UploadFileModel);

        if (uploadFile.IsError)
        {
            return uploadFile.Errors;
        }

        Category category = new Category(model.Name, model.Description, model.Slug, model.MetaDescription,
            model.KeyWords, model.ParentCategoryId, userId, uploadFile.Value, true);

        await categoryRepository.CreateAsync(category);
        if (await categoryRepository.SaveChangesAsync())
        {
            return Result.Created;
        }

        fileService.RemoveFileLocal(uploadFile.Value.FilePath);
        return Error.Failure();
    }

    public async Task<ErrorOr<Updated>> UpdateCategory(UpdateCategoryModel model, long userId)
    {
        Category category = await categoryRepository.GetByIdAsync(model.Id);
        
        if (await categoryRepository.IsCategoryDuplicate(model.Name.ToLower(), model.Slug.ToLower()))
        {
            return Error.Conflict();
        }

        var oldId = category.IconId;
        if (model.UploadFileModel != null)
        {
            var uploadFile = await fileService.SaveAndCreateUploadFile(model.UploadFileModel);

            if (uploadFile.IsError)
            {
                return uploadFile.Errors;
            }
            
            category.ChangeIcon(uploadFile.Value.Id);
        }
        category.Update(model.Name, model.Description, model.Slug, model.MetaDescription,
            model.KeyWords, model.ParentCategoryId, userId);

        await categoryRepository.CreateAsync(category);
        if (await categoryRepository.SaveChangesAsync())
        {
            if (category.IconId != oldId)
            {
                fileService.RemoveFile(oldId);
            }
            return Result.Updated;
        }

        return Error.Failure();
    }

    public async Task<ErrorOr<Deleted>> RemoveCategoryBy(long Id, long userId)
    {
        Category category = await categoryRepository.GetByIdAsync(Id);
        
        category.Remove(userId);
        if (await categoryRepository.SaveChangesAsync())
        {
            return Result.Deleted;
        }

        return Error.Failure();
    }

    public Task<ErrorOr<UpdateCategoryModel>> GetCategoryDetailBy(long Id)
    {
        throw new NotImplementedException();
    }

    public Task<ErrorOr<PaginatedResult<CategoryViewModel>>> GetCategoryAdminListBy(SearchCategoryModel searchModel)
    {
        throw new NotImplementedException();
    }

    public Task<ErrorOr<PaginatedResult<QueryCategoryModel>>> GetCategoryList()
    {
        throw new NotImplementedException();
    }
}