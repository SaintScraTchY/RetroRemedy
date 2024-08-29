namespace RetroRemedy.Common.Contracts.TagContracts;

public class TagViewModel
{
    public long Id { get; set; }
    public string Name { get; set; }
    public string CreatedBy { get; set; }
    public string CreatedDateTime { get; set; }
    public string UpdatedBy { get; set; }
    public string UpdateDateTime { get; set; }
    public bool IsActive { get; set; }
    public bool IsRemoved { get; set; }
}