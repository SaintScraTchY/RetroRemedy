namespace RetroRemedy.Core.Common;

public class BasicEntity
{
    public long Id { get; set; }
    public DateTime CreateDateTime { get; set; }
    public bool IsRemoved { get; set; }

    public BasicEntity()
    {
        CreateDateTime = DateTime.UtcNow;
        IsRemoved = false;
    }
}