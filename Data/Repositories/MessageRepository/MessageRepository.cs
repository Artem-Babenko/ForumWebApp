using ForumWebApp.Data.Entities;
using ForumWebApp.Models;
using Microsoft.Extensions.Options;

namespace ForumWebApp.Data.Repositories;

public class MessageRepository :  BaseRepository, IMessageRepository
{
    public MessageRepository(IOptionsSnapshot<ConnectionStrings> options) : base(options) { }

    public MessageEntity? Get(int id)
    {
        throw new NotImplementedException();
    }

    public IList<MessageEntity> GetAll()
    {
        throw new NotImplementedException();
    }

    public MessageEntity Add(MessageEntity message)
    {
        throw new NotImplementedException();
    }

    public bool Update(MessageEntity message)
    {
        throw new NotImplementedException();
    }

    public bool Delete(int id)
    {
        throw new NotImplementedException();
    }
}
