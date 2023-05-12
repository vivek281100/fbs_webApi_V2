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
            var checkadmin = await _context.Admins.FirstOrDefaultAsync(a => a.Admin_Id == admin.Admin_Id);
            if(checkadmin == null)
            {
                await _context.Admins.AddAsync(admin);
                await _context.SaveChangesAsync();
                return  true;
            }

            return false;
        }

        public async Task<bool> DeleteAdminAsync(int id)
        {
            var admin = await _context.Admins.FirstOrDefaultAsync(u => u.Admin_Id == id);
            if (admin == null)
            {
                return false;
            };
            _context.Admins.Remove(admin);

            await _context.SaveChangesAsync();
            return true;
        }
    

        public async Task<Admin?> GetAdminByEmailAsync(string email)
        {
            var admin = await _context.Admins.FirstOrDefaultAsync(u => u.Email_Id == email);
            return admin;
        }

        public  async Task<Admin?> GetAdminByIdAsync(int id)
        {
            var admin = await _context.Admins.FirstOrDefaultAsync(u => u.Admin_Id == id);
            return admin;
        }

        public  async Task<Admin?> GetAdminByUsernameAsync(string adminname)
        {
            var admin = await _context.Admins.FirstOrDefaultAsync(u => u.Admin_Name == adminname);
            return admin;
        }

        public async Task<List<Admin>> GetAllAdminsAsync()
        {
            var admins = await _context.Admins.ToListAsync();
            return admins;
        }

        public async Task<bool> UpdateAdminAsync(Admin admin)
        {
            var adminupdate = await _context.Admins.FindAsync(admin.Admin_Id);
            if (adminupdate != null)
            {
                adminupdate.Admin_Name = admin.Admin_Name;
                adminupdate.Email_Id = admin.Email_Id;
               
               await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
