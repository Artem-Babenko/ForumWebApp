using Microsoft.Extensions.Options;

namespace ForumWebApp.Data.Repositories;

public class MessageRepository :  BaseRepository, IMessageRepository
{
    public MessageRepository(IOptionsSnapshot<ConnectionStrings> options) : base(options) { }
}
