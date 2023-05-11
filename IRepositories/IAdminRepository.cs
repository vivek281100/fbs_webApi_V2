using System;
using fbs_webApi_v2.DataModels;

namespace fbs_webApi_v2.IRepositories
{
    public interface IAdminRepository
    {
        Task<List<Admin>> GetAllAdminsAsync();

        Task<Admin?> GetAdminByIdAsync(int id);

        Task<Admin?> GetAdminByEmailAsync(string email);

        Task<Admin?> GetAdminByUsernameAsync(string username);

        Task<bool> AddAdminAsync(Admin admin);
        Task<bool> UpdateAdminAsync(Admin admin);

        Task<bool> DeleteAdminAsync(int id);

    }
}
