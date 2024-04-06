using ForumWebApp.Data.Repositories;

namespace ForumWebApp.Extensions;

public static class IoCExtensions
{
    public static void AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IUserRepository, UserRepository>();
    }
}
