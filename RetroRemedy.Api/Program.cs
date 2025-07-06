using Microsoft.EntityFrameworkCore;
using RetroRemedy.Infrastructure;
using RetroRemedy.Infrastructure.Configuration;
using RetroRemedy.Services.Configuration;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddDbContext<RetroContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"), optionsBuilder =>
    {
        optionsBuilder.EnableRetryOnFailure(3);
        optionsBuilder.CommandTimeout(3000);
    });

    options.EnableSensitiveDataLogging(false);
    options.EnableDetailedErrors(false);
    options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
});

//builder.ConfigureDatabase();
builder.ConfigureIdentity();
builder.AddRepositories();
builder.AddServices();
//builder.ConfigureWebConfigs();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}
app.MapScalarApiReference();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();