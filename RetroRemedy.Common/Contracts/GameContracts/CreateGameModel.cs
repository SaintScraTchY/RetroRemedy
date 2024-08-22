namespace RetroRemedy.Common.Contracts.GameContracts;

public class CreateGameModel
{
    public string Title { get; set; }
    public string Description { get; set; }
    public DateOnly ReleaseDate { get; set; }
    public long PublisherId { get; private set; }
    public UploadFileModel ThumbnailFile { get; set; }
    public IEnumerable<long> tagIds { get; set; }
    public IEnumerable<UploadFileModel> Files { get; set; }
}