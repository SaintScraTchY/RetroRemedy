using Microsoft.AspNetCore.Http;

namespace RetroRemedy.Common.Contracts;

public class UploadFileModel : SelectListModel
{
    public string Caption { get; set; }
    public ushort Order { get; set; }
    public IFormFile File { get; set; }
    public string WebUrl { get; set; }
}