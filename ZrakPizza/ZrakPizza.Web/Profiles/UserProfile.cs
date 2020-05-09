using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
