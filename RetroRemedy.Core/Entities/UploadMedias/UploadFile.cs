using RetroRemedy.Core.Common;
using RetroRemedy.Core.Entities.BlogPosts;
using RetroRemedy.Core.Entities.Games;
using RetroRemedy.Core.Entities.Publishers;
using RetroRemedy.Core.Enums;

namespace RetroRemedy.Core.Entities.UploadMedias;

public class UploadFile : BasicEntity
{
    public string AltText { get; private set; }
    public string Caption { get; private set; }
    public MediaType MediaType { get; private set; }
    public string WebUrl { get; private set; }
    public string FilePath { get; private set; }
    public ushort Order { get; set; } = 0;

    public Game Game { get; set; }
    public long? GameId { get; set; }
    
    public BlogPost BlogPost { get; set; }
    public long? BlogPostId { get; set; } 

    protected UploadFile()
    {
        
    }

    public UploadFile(string altText, string caption,ushort order, MediaType mediaType, string webUrl, 
        string filePath)
    {
        AltText = altText;
        Caption = caption;
        Order = order;
        MediaType = mediaType;
        WebUrl = webUrl;
        FilePath = filePath;
    }
    
    public void Update(string? altText, string? caption,ushort? order)
    {
        AltText = altText ?? AltText;
        Caption = caption ?? Caption;
        Order = order ?? Order;
    }
}