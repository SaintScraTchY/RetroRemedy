namespace RetroRemedy.Common.Contracts.CategoryContracts;

public class CreateCategoryModel
{
    public string Name { get; set; }
    public string? Description { get; set; }
    public string Slug { get; set; }
    public string MetaDescription { get; set; }
    public string KeyWords { get; set; }
    public long? ParentCategoryId { get; set; }
    public UploadFileModel UploadFileModel { get; set; }
}