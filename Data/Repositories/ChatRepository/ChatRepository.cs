using ForumWebApp.Data.Entities;
using ForumWebApp.Models;
using Microsoft.Extensions.Options;

namespace ForumWebApp.Data.Repositories;

public class ChatRepository : BaseRepository, IChatRepository
{
    public ChatRepository(IOptionsSnapshot<ConnectionStrings> options) : base(options) { }

    public ChatEntity? Get(int id)
    {
        throw new NotImplementedException();
    }

    public IList<ChatEntity> GetAll()
    {
        throw new NotImplementedException();
    }

    public ChatEntity Add(ChatEntity chat)
    {
        throw new NotImplementedException();
    }

    public bool Update(ChatEntity chat)
    {
        throw new NotImplementedException();
    }

    public bool Delete(int id)
    {
        throw new NotImplementedException();
    }
}
