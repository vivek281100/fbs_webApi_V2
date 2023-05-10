using System;
using System.Collections.Generic;
using fbs_webApi_v2.Data;
using fbs_webApi_v2.IRepositories;
using fbs_webApi_v2.DataModels;
using Microsoft.EntityFrameworkCore;

namespace fbs_webApi_v2.Repositories
{
    public class AdminRepository : IAdminRepository
    {
        private readonly fbscontext _context;

        public AdminRepository(fbscontext context)
        {
            _context = context;
        }

        public async Task<bool> AddAdminAsync(Admin admin)
        {
            var checkadmin = _context.Admins.FirstOrDefaultAsync(a => a.Admin_Id == admin.Admin_Id);
            if(checkadmin == null)
            {
                await _context.Admins.AddAsync(admin);
                await _context.SaveChangesAsync();
                return  true;
            }

            return false;
        }

        public async Task DeleteAdminAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Admin> GetAdminByEmailAsync(string email)
        {
            throw new NotImplementedException();
        }

        public  async Task<Admin> GetAdminByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public  async Task<Admin> GetAdminByUsernameAsync(string username)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Admin>> GetAllAdminsAsync()
        {
            return await _context.Admins.ToListAsync();
        }

        public async Task<bool> UpdateAdminAsync(Admin admin)
        {
            throw new NotImplementedException();
        }
    }
}
