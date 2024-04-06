using ForumWebApp.Data.Entities;

namespace ForumWebApp.Data.Repositories;

public interface IUserRepository
{
    IList<UserEntity> GetAll();

    UserEntity? Get(int id);

    void Update(UserEntity user);

    void Delete(int id);
}
