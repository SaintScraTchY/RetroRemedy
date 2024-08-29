namespace RetroRemedy.Common.Contracts.CategoryContracts;

public class CategoryViewModel
{
    public string Name { get; set; }
    public string Slug { get; set; }
    public string KeyWords { get; set; }
    public string ParentCategory { get; set; }
    public string CreatedBy { get; set; }
    public string CreatedDateTime { get; set; }
    public string UpdatedBy { get; set; }
    public string UpdateDateTime { get; set; }
    public bool IsActive { get; set; }
    public bool IsRemoved { get; set; }
}