using ForumWebApp.Extensions;

var configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .Build();

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<ConnectionStrings>(configuration.GetSection("ConnectionStrings"));
builder.Services.AddControllers();
builder.Services.AddRepositories();

var app = builder.Build();

app.UseStaticFiles();
app.MapControllers();

app.Run();

public record class ConnectionStrings
{
    public required string DefaultConnection { get; set; }
}
