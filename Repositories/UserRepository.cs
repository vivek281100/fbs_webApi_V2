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

        public async Task<bool> DeleteUserAsync(int userId)
        {
            var user = await _context.users.FirstOrDefaultAsync(u => u.User_Id ==  userId);
            if(user == null)
            {
                return false;
            };
             _context.users.Remove(user);

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<User> GetUserByPhonenumberAsync(string phonenumber)
        {
            var user = await _context.users.FirstOrDefaultAsync(u => u.PhoneNumber == phonenumber);
            return user;
        }

        public async Task<User> GetUserByUser_EmailAsync(string email)
        {
            var user = await _context.users.FirstOrDefaultAsync(u => u.Email == email);
            return user;
        }

        public async Task<User> GetUserByUser_IdAsync(int userId)
        {
            var user = await _context.users.FirstOrDefaultAsync(u => u.User_Id == userId);
            return user;
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

        public async Task<bool> UpdateUserAsync(User user)
        {
            var userupdate = await _context.users.FirstOrDefaultAsync(u => u.User_Id == user.User_Id);
            if (userupdate != null) 
            {
                userupdate = user;
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
