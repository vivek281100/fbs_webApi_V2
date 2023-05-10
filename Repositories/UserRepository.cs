using System;
using System.Collections.Generic;
using fbs_webApi_v2.Data;
using fbs_webApi_v2.IRepositories;
using fbs_webApi_v2.DataModels;
using Microsoft.EntityFrameworkCore;

namespace fbs_webApi_v2.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly fbscontext _context;

        public UserRepository(fbscontext context) 
        {
            _context = context;
        }

        public async Task<bool> CreateUserAsync(User user)
        {
            var checkuser = await _context.users.FirstOrDefaultAsync(u => u.User_Id == user.User_Id);
            if (checkuser == null)
            {
                await _context.users.AddAsync(user);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public Task DeleteUserAsync(int userId)
        {
            throw new NotImplementedException();
        }

        public Task<User> GetUserByPhonenumberAsync(string phonenumber)
        {
            throw new NotImplementedException();
        }

        public Task<User> GetUserByUser_EmailAsync(string email)
        {
            throw new NotImplementedException();
        }

        public Task<User> GetUserByUser_IdAsync(int userId)
        {
            throw new NotImplementedException();
        }

        public async Task<User?> GetUserByUser_NameAsync(string name)
        {
            var userbyname = await _context.users.FirstOrDefaultAsync(u => u.User_Name == name);
            return  userbyname;
        }

        public async Task<List<User>> GetUsersAsync()
        {
            return await _context.users.ToListAsync();
        }

        public Task<bool> UpdateUserAsync(User user)
        {
            throw new NotImplementedException();
        }
    }
}
