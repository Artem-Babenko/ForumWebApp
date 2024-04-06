using ForumWebApp.Data.Entities;

namespace ForumWebApp.Data.Repositories;

public interface IUserRepository
{
    IList<UserEntity> GetAll();

    UserEntity? Get(int id);

    UserEntity Add(UserEntity user);

    void Update(UserEntity user);

    bool Delete(int id);
}
