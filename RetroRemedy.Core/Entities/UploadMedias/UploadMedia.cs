using RetroRemedy.Core.Common;
using RetroRemedy.Core.Entities.BlogPosts;
using RetroRemedy.Core.Entities.Games;
using RetroRemedy.Core.Enums;

namespace RetroRemedy.Core.Entities.UploadMedias;

public class UploadMedia : BasicEntity
{
    public string? AltText { get; private set; }
    public string Caption { get; private set; }
    public MediaType MediaType { get; private set; }
    public string WebUrl { get; private set; }
    public string FilePath { get; private set; }
    
    public long? GameId { get; set; } 
    public long? BlogPostId { get; set; } 
    public Game Game { get; set; }
    public BlogPost BlogPost { get; set; }

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