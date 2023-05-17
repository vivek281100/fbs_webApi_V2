using System;
using fbs_webApi_v2.Data;
using fbs_webApi_v2.DataModels;
using fbs_webApi_v2.DTOs.UserDtos;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;

namespace fbs_webApi_v2.services.IRepositories
{
    public interface IUserRepository
    {
        //Task<serviceResponce<List<GetUserDto>>> GetUsersAsync();

        //Task<serviceResponce<GetUserDto>> Register(AddUserDto addUserDto);
        //Task<serviceResponce<GetUserDto>> GetUserByUser_IdAsync(int userId);

        //Task<serviceResponce<GetUserDto>> GetUserByUserNameAsync(string name);

        Task<serviceResponce<GetUserDto>> GetUserByEmailAsync(string email);

        //Task<serviceResponce<GetUserDto>> GetUserByPhonenumberAsync(string phonenumber);

        //Task<serviceResponce<List<GetUserDto>>> AddUserAsync(AddUserDto adduser);
        //Task<serviceResponce<GetUserDto>> Login(string username, string password);

        Task<serviceResponce<GetUserDto>> UpdateUserAsync(updateUserDto updateuser);

        Task<serviceResponce<List<GetUserDto>>> DeleteUserAsync(int userId);

    }
}
