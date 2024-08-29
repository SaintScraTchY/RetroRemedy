using ErrorOr;
using RetroRemedy.Common.Contracts.CategoryContracts;
using RetroRemedy.Core.Common;

namespace RetroRemedy.Services.IService;

public interface ICategoryService
{
    Task<ErrorOr<Created>> CreateCategory(CreateCategoryModel model,long userId);
    Task<ErrorOr<Updated>> UpdateCategory(UpdateCategoryModel model,long userId);
    Task<ErrorOr<Deleted>> RemoveCategoryBy(long Id,long userId);
    Task<ErrorOr<UpdateCategoryModel>> GetCategoryDetailBy(long Id);
    Task<ErrorOr<PaginatedResult<CategoryViewModel>>> GetCategoryAdminListBy(SearchCategoryModel searchModel);
    Task<ErrorOr<PaginatedResult<QueryCategoryModel>>> GetCategoryList();
}