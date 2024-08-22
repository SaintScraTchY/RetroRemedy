using RetroRemedy.Common.Helpers;

namespace RetroRemedy.Web.Configuration;

public static class BlazorConfiguration
{
    public static void ConfigureWebConfigs(this WebApplicationBuilder builder)
    {
       AppConst.RootPath = builder.Environment.WebRootPath;
    }
}