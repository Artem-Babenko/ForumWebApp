using Microsoft.AspNetCore.ResponseCompression;
using ForumWebApp.Extensions;
using ForumWebApp.Models;
using ForumWebApp.Data;
using ForumWebApp.SignalRHubs;

var configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .Build();

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAutoMapper(opt => opt.AddProfile<EntityProfile>());
builder.Services.Configure<ConnectionStrings>(configuration.GetSection("ConnectionStrings"));
builder.Services.AddControllers();
builder.Services.AddRepositories();
builder.Services.AddSignalR();
builder.Services.AddResponseCompression(config =>
{
    config.Providers.Add<GzipCompressionProvider>();
    config.Providers.Add<BrotliCompressionProvider>();
});

var app = builder.Build();

app.MapHub<ChatHub>("/api/chat");
app.UseStaticFiles();
app.MapControllers();
app.UseResponseCompression();

app.Run();
