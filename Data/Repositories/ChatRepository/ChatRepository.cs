using ForumWebApp.Models;
using Microsoft.Extensions.Options;

namespace ForumWebApp.Data.Repositories;

public class ChatRepository : BaseRepository, IChatRepository
{
    public ChatRepository(IOptionsSnapshot<ConnectionStrings> options) : base(options) { }
}
