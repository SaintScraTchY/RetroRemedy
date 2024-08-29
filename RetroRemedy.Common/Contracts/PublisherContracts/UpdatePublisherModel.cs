namespace RetroRemedy.Common.Contracts.PublisherContracts;

public class UpdatePublisherModel
{
    public long Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public string? Slug { get; set; }
    public string? MeteDescription { get; set; }
    public string? KeyWords { get; set; }
    public string? WebsiteUrl { get; set; }
    public string? WikipediaUrl { get; set; }
    public UploadFileModel? ThumbnailModel { get; set; }
}