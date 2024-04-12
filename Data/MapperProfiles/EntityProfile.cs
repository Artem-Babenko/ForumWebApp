using AutoMapper;
using ForumWebApp.Data.Entities;
using ForumWebApp.Models;
using ForumWebApp.Models;

namespace ForumWebApp.Data;

public class EntityProfile : Profile
{
    public EntityProfile()
    {
        #region User

        CreateMap<UserEntity, UserFullModel>().ReverseMap();

        CreateMap<UserSmallModel, UserEntity>().ReverseMap();

        #endregion
    }
}
