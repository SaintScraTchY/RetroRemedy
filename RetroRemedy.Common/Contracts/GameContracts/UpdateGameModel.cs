namespace RetroRemedy.Common.Contracts.GameContracts;

public class UpdateGameModel
{
    public  long Id { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }
    public DateOnly? ReleaseDate { get; set; }
    public long? PublisherId { get; private set; }
    public UploadFileModel? ThumbnailFile { get; set; }
    public IEnumerable<SelectListModel> TagIds { get; set; }
    public IEnumerable<UploadFileModel> Files { get; set; }
}