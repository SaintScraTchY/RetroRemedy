using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Http;

namespace RetroRemedy.Common.Contracts;

public class UploadFileModel : SelectListModel
{
    public string Caption { get; set; }
    public ushort Order { get; set; }
    public IBrowserFile File { get; set; }
    public string WebUrl { get; set; }
}