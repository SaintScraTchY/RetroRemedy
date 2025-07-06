using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using RetroRemedy.Services.IService;
using RetroRemedy.Services.Service;

namespace RetroRemedy.Services.Configuration;

public static class ConfigureService
{
    public static void AddServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<IUploadFileService, UploadFileService>();
        builder.Services.AddScoped<IGameService, GameService>();
        builder.Services.AddScoped<IValidatorService, ValidatorService>();
    }
}