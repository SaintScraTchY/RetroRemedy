using RetroRemedy.Core.Entities.AppUsers;

namespace RetroRemedy.Core.Common;

public class BaseEntity : BasicEntity
{
    public DateTime? UpdateDateTime { get; set; }
    public long CreatedById { get; set; }
    public AppUser CreatedBy { get; set; }
    public long? UpdatedById { get; set; }
    public AppUser? UpdatedBy { get; set; }
    public bool IsActive { get; set; }
    public byte[] RowVersion { get; set; } 
    protected BaseEntity(long userId = 1,bool isActive = false)
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

    public void Remove(long userId)
    {
        UpdateTimestamp(userId);
        IsRemoved = true;
    }
    
    public void Restore(long userId)
    {
        UpdateTimestamp(userId);
        IsRemoved = false;
    }

    public void ToggleActiveState(long userId)
    {
        UpdateTimestamp(userId);
        IsActive = !IsActive;
    }
    
    public void Activate(long userId)
    {
        UpdateTimestamp(userId);
        IsActive = true;
        IsRemoved = false;
    }
    
    public void Deactivate(long userId)
    {
        UpdateTimestamp(userId);
        IsActive = false;
    }
}