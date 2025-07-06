using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RetroRemedy.Core.Common;
using RetroRemedy.Core.Entities.AppUsers;
using RetroRemedy.Core.Entities.BlogEntities;
using RetroRemedy.Core.Entities.GameCategories;
using RetroRemedy.Core.Entities.LabelEntities;
using RetroRemedy.Core.Entities.UploadMedias;
using RetroRemedy.Infrastructure.Common;
using RetroRemedy.Infrastructure.Repositories;

namespace RetroRemedy.Infrastructure.Configuration;

public static class ConfigureInfrastructure
{
    public static void ConfigureDatabase(this WebApplicationBuilder builder)
    {
        builder.Services.AddDbContext<RetroContext>(options =>
            options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
    }
    
    public static void ConfigureIdentity(this WebApplicationBuilder builder)
    {
        builder.Services.AddIdentity<AppUser, IdentityRole<long>>(options =>
            {
                // Password settings
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = true;
                options.Password.RequiredLength = 6;

                // Lockout settings
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                options.Lockout.MaxFailedAccessAttempts = 5;

                // User settings
                options.User.RequireUniqueEmail = true;
            })
            .AddEntityFrameworkStores<RetroContext>()
            .AddDefaultTokenProviders();

        // Configure Authentication with Cookies
        builder.Services.ConfigureApplicationCookie(options =>
        {
            options.LoginPath = "/Account/Login";
            options.AccessDeniedPath = "/Account/AccessDenied";
            options.SlidingExpiration = true;
            options.ExpireTimeSpan = TimeSpan.FromMinutes(30);
            options.Cookie.HttpOnly = true; // Prevent JavaScript access to the cookie
            options.Cookie.SecurePolicy = CookieSecurePolicy.Always; // Ensure cookies are only sent over HTTPS
        });
        
        builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
            .AddCookie(options =>
            {
                options.LoginPath = "/login";
                options.AccessDeniedPath = "/accessdenied";
            });

        builder.Services.AddAuthorization(options =>
        {
            options.AddPolicy("AdminPolicy", policy => policy.RequireRole("Admin"));
        });

        
        // 2. Add Authorization and Roles
        builder.Services.AddAuthorization(options =>
        {
            // Here you can add custom policies if needed
        });
    }
    
    public static void AddRepositories(this WebApplicationBuilder builder)
    {
        builder.Services.AddScoped(typeof(IBaseRepository<>),typeof(BaseRepository<>));
        builder.Services.AddScoped<IUploadFileRepository, UploadFileRepository>();
        builder.Services.AddScoped<ICategoryRepository,CategoryRepository>();
        builder.Services.AddScoped<ITagRepository,TagRepository>();
        builder.Services.AddScoped<IGameRepository,GameRepository>();
        builder.Services.AddScoped<IBlogPostRepository,BlogPostRepository>();
        builder.Services.AddScoped<IGameTagRepository,GameTagRepository>();
        builder.Services.AddScoped<IBlogPostTagRepository,BlogPostTagRepository>();
    }
    
    public static void ConfigureExternal(this WebApplicationBuilder builder)
    {
        
    }
}