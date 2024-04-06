using Microsoft.Extensions.Options;

namespace ForumWebApp.Data.Repositories.ChatRepository;

public class ChatRepository : BaseRepository, IChatRepository
{
    public ChatRepository(IOptionsSnapshot<ConnectionStrings> options) : base(options) { }
}
