using ForumWebApp.Data.Entities;

namespace ForumWebApp.Data.Repositories;

public interface IMessageRepository
{
    IList<MessageEntity> GetAll();

    MessageEntity? Get(int id);

    MessageEntity Add(MessageEntity message);

    bool Update(MessageEntity message);

    bool Delete(int id);
}
