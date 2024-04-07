using ForumWebApp.Data.Entities;

namespace ForumWebApp.Data.Repositories;

public interface IChatRepository
{
    IList<ChatEntity> GetAll();

    ChatEntity? Get(int id);

    ChatEntity Add(ChatEntity chat);

    bool Update(ChatEntity chat);

    bool Delete(int id);
}
