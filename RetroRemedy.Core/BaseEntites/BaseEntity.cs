using RetroRemedy.Core.Entities.AppUsers;

namespace RetroRemedy.Core.BaseEntites;

public class BaseEntity : BasicEntity
{
    public DateTime UpdateDateTime { get; set; }
    public long CreatedById { get; set; }
    public AppUser CreatedBy { get; set; }
    public long? UpdatedById { get; set; }
    public AppUser? UpdatedBy { get; set; }
    public bool IsActive { get; set; }
    public byte[] RowVersion { get; set; } 
    protected BaseEntity(long userId,bool isActive = false)
    {
        UpdateDateTime = CreateDateTime;
        IsActive = isActive;
        CreatedById = userId;
    }
    
    private protected void UpdateTimestamp(long userId)
    {
        UpdateDateTime = DateTime.UtcNow;
        UpdatedById = userId;
    }

    public void Remove()
    {
        IsRemoved = true;
    }
    
    public void Restore()
    {
        IsRemoved = false;
    }

    public void ToggleActiveState()
    {
        IsActive = !IsActive;
    }
    
    public void Activate()
    {
        IsActive = true;
        IsRemoved = false;
    }
    
    public void Deactivate()
    {
        IsActive = false;
    }
}