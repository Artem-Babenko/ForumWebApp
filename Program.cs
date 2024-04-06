using ForumWebApp.Extensions;
using Microsoft.AspNetCore.ResponseCompression;

var configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .Build();

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<ConnectionStrings>(configuration.GetSection("ConnectionStrings"));
builder.Services.AddControllers();
builder.Services.AddRepositories();
builder.Services.AddResponseCompression(config =>
{
    config.Providers.Add<GzipCompressionProvider>();
    config.Providers.Add<BrotliCompressionProvider>();
});

var app = builder.Build();

app.UseStaticFiles();
app.MapControllers();
app.UseResponseCompression();

app.Run();

public record class ConnectionStrings
{
    public required string DefaultConnection { get; set; }
}
