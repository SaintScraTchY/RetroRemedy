namespace RetroRemedy.Common.Contracts;

public class SelectListModel
{
    public long Key { get; set; }
    public string Value { get; set; }
    public bool IsDeleted { get; set; }
    public bool IsAdded { get; set; }
}