using System;
using AutoMapper;
using Ownerofglory.Tasket.Backend.Data.Model;
using Ownerofglory.Tasket.Backend.Security.Model;

namespace Ownerofglory.Tasket.Backend.Security.Helper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, UserModel>();
            CreateMap<UserRegisterModel, User>();
            CreateMap<UserUpdateModel, User>();
        }
    }
}
