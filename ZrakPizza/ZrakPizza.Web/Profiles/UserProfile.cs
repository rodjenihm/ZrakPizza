using AutoMapper;
using ZrakPizza.DataAccess.Entities;
using ZrakPizza.Web.Dto;
using ZrakPizza.Web.Resources;

namespace ZrakPizza.Web.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserDto, User>();
            CreateMap<User, UserResource>();
        }
    }
}
