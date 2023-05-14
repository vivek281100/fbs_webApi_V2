
using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using fbs_webApi_v2.DataModels;
using fbs_webApi_v2.DTOs.AdminDtos;
using fbs_webApi_v2.DTOs.UserDtos;

namespace fbs_webApi_v2
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            //admin
            CreateMap<Admin,GetAdminDto>();
            CreateMap<AddAdminDto, Admin>();
            CreateMap<UpdateAdminDto, Admin>();

            //User
            CreateMap<User,GetUserDto>();
            CreateMap<AddUserDto, User>();
            CreateMap<updateUserDto, User>();
        }
    }
}
