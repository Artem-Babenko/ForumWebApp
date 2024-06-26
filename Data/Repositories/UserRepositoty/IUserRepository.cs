﻿using ForumWebApp.Data.Entities;

namespace ForumWebApp.Data.Repositories;

public interface IUserRepository
{
    IList<UserEntity> GetAll();

    IList<UserEntity> GetAllByName(string value);

    UserEntity? Get(int id);

    UserEntity Add(UserEntity user);

    bool Update(UserEntity user);

    bool Delete(int id);
}
