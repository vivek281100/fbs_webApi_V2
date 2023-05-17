using System;
using System.Collections.Generic;
using fbs_webApi_v2.Data;
using fbs_webApi_v2.DataModels;
using Microsoft.EntityFrameworkCore;
using fbs_webApi_v2.services.IRepositories;
using AutoMapper;
using fbs_webApi_v2.DTOs.AdminDtos;
using fbs_webApi_v2.DTOs.UserDtos;

namespace fbs_webApi_v2.services.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly fbscontext _context;
        private readonly IMapper _mapper;

        //controller
        public UserRepository(fbscontext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        //add user
        #region AddUserAsync
        //Add user to db
        //admin access
        //public async Task<serviceResponce<List<GetUserDto>>> AddUserAsync(AddUserDto newUser)
        //{
        //    var user = _context

        //    var responce = new serviceResponce<List<GetUserDto>>();

        //    _context.users.Add(_mapper.Map<User>(newUser));
        //    await _context.SaveChangesAsync();

        //    responce.Data = await _context.users.Select(a => _mapper.Map<GetUserDto>(a)).ToListAsync();

        //    return responce;

        //}
        #endregion

        //Delete User
        public async Task<serviceResponce<List<GetUserDto>>> DeleteUserAsync(int id)
        {
            var user = await _context.users.FirstOrDefaultAsync(u => u.Id == id);

            serviceResponce<List<GetUserDto>> responce = new serviceResponce<List<GetUserDto>>();

            if (user == null)
            {
                responce.Success = false;
                responce.Message = "user not found";
                return responce;
            };

            _context.users.Remove(user);

            await _context.SaveChangesAsync();
            responce.Message = "user removed";
            return responce;
        }


        //Gets user by email id
        public async Task<serviceResponce<GetUserDto>> GetUserByEmailAsync(string email)
        {
            var user = await _context.users.FirstOrDefaultAsync(u => u.Email == email);
            if (user == null)
            {
                var userobj = _mapper.Map<GetUserDto>(user);
                return new serviceResponce<GetUserDto> { Data = userobj, Message = "User Found" };
            }
            return new serviceResponce<GetUserDto> { Success = false, Message = "user not found" };
        }


        #region( Previous methods)
        //public async Task<serviceResponce<GetUserDto>> GetUserByUserNameAsync(string username)
        //{
        //    var user = await _context.users.FirstOrDefaultAsync(u => u.User_Name == username);
        //    if (user == null)
        //    {
        //        var userobj = _mapper.Map<GetUserDto>(user);
        //        return new serviceResponce<GetUserDto> { Data = userobj, Message = "User found" };
        //    }
        //    return new serviceResponce<GetUserDto> { Success = false, Message = "User not found" };
        //}

        //public async Task<serviceResponce<List<GetUserDto>>> GetAllUsersAsync()
        //{
        //    var responce = new serviceResponce<List<GetUserDto>>();

        //    var userslist = await _context.users.ToListAsync();
        //    if (userslist.Count != 0)
        //    {
        //        responce.Data = userslist.Select(a => _mapper.Map<GetUserDto>(a)).ToList();
        //        responce.Message = "Users retrived";
        //        return responce;
        //    }

        //    responce.Success = false;
        //    responce.Message = "No Entries";

        //    return responce;
        //}

        #endregion


        //Update User
        public async Task<serviceResponce<GetUserDto>> UpdateUserAsync(updateUserDto updateuser)
        {
            User userupdate = await _context.users.FindAsync(updateuser.User_Id);

            serviceResponce<GetUserDto> responce = new serviceResponce<GetUserDto>();

            if (userupdate != null)
            {

                _mapper.Map(updateuser, userupdate);

                await _context.SaveChangesAsync();
                responce.Data = _mapper.Map<GetUserDto>(userupdate);
                responce.Message = "update Completed";
                return responce;
            }
            responce.Success = false;
            responce.Message = "update not done, user not found";
            return responce;

        }


    }
}
