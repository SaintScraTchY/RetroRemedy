namespace RetroRemedy.Common.Contracts.CategoryContracts;

public class SearchCategoryModel
{
    public string? Name { get; set; }
    public string? KeyWords { get; set; }
    public long? ParentCategoryId { get; set; }
}