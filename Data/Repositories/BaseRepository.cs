using Microsoft.Extensions.Options;

namespace ForumWebApp.Data.Repositories;

public abstract class BaseRepository
{
    protected readonly string ConnectionString;

    protected BaseRepository(IOptionsSnapshot<ConnectionStrings> connectionOptions)
    {
        ConnectionString = connectionOptions.Value.DefaultConnection;
    }
}
