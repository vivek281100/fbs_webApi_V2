using System;
using System.Collections.Generic;
using fbs_webApi_v2.Data;
using fbs_webApi_v2.DataModels;
using Microsoft.EntityFrameworkCore;
using fbs_webApi_v2.services.IRepositories;
using AutoMapper;
using fbs_webApi_v2.DTOs.AdminDtos;
using fbs_webApi_v2.DTOs.UserDtos;
using System.Security.Claims;

namespace fbs_webApi_v2.services.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly fbscontext _context;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _contextAccessor;

        //controller
        public UserRepository(fbscontext context, IMapper mapper,IHttpContextAccessor contextAccessor)
        {
            _context = context;
            _mapper = mapper;
            _contextAccessor = contextAccessor;
        }

        #region get user id

        private int getUserId()
        {
            var id = _contextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            return int.Parse(id);
        }
        #endregion


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



        //get user by user id
        public async Task<serviceResponce<GetUserDto>> GetUserByUser_IdAsync()
        {
            var responce = new serviceResponce<GetUserDto>();
            try
            {
                var user = await  _context.users.Where(u => u.Id == getUserId()).FirstOrDefaultAsync();

                if (user != null) {
                    responce.Data = _mapper.Map<GetUserDto>(user);
                    responce.Success = true;
                    responce.Message = "details retrived";
                }
                else
                {
                    responce.Success = false;
                    responce.Message = "user not found";
                }

                return responce;
            }
            catch (Exception ex)
            {
                responce.Success = false;
                responce.Message = ex.Message;
                return responce;
            }
        }



        //Delete User
        public async Task<serviceResponce<GetUserDto>> DeleteUserAsync()
        {
            var user = await _context.users.FirstOrDefaultAsync(u => u.Id == getUserId());

            var responce = new serviceResponce<GetUserDto>();

            if (user == null)
            {
                responce.Success = false;
                responce.Message = "user not found";
                return responce;
            };

            _context.users.Remove(user);

            await _context.SaveChangesAsync();
            responce.Data = _mapper.Map<GetUserDto>(user);
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
        public async Task<serviceResponce<GetUserDto>> UpdateUserAsync(userupdateForUserDto updateuser)
        {
            User userupdate = await _context.users.FindAsync(getUserId());

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
