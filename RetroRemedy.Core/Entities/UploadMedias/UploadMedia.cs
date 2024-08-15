using RetroRemedy.Core.Enums;

namespace RetroRemedy.Core.Entities.UploadMedias;

public class UploadMedia : BasicEntity
{
    public string? AltText { get; private set; }
    public string Caption { get; private set; }
    public MediaType MediaType { get; private set; }
    public string WebUrl { get; private set; }
    public string FilePath { get; private set; }

    protected UploadMedia(string? altText, string caption, MediaType mediaType, string webUrl, 
        string filePath)
    {
        AltText = altText;
        Caption = caption;
        MediaType = mediaType;
        WebUrl = webUrl;
        FilePath = filePath;
    }
}