using AutoMapper;
using ForumWebApp.Data.Entities;
using ForumWebApp.Models;

namespace ForumWebApp.Data;

public class EntityProfile : Profile
{
    public EntityProfile()
    {
        #region User

        CreateMap<UserEntity, UserModel>().ReverseMap();

        #endregion
    }
}
