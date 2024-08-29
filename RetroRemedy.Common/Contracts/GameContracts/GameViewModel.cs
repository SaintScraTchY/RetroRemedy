namespace RetroRemedy.Common.Contracts.GameContracts;

public class GameViewModel
{
    public string Title { get; set; }
    public string Description { get; set; }
    public DateOnly ReleaseDate { get; set; }
    public string Publisher{ get; private set; }
    public string CreatedBy { get; set; }
    public string CreatedDateTime { get; set; }
    public string UpdatedBy { get; set; }
    public string UpdateDateTime { get; set; }
}