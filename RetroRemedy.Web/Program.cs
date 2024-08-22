using Microsoft.EntityFrameworkCore;
using RetroRemedy.Infrastructure;
using RetroRemedy.Infrastructure.Configuration;
using RetroRemedy.Services.Configuration;
using RetroRemedy.Web.Components;
using RetroRemedy.Web.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddDbContext<RetroContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

//builder.ConfigureDatabase();
builder.ConfigureIdentity();
builder.AddRepositories();
builder.AddServices();
builder.InjectLibraries();
builder.ConfigureWebConfigs();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();