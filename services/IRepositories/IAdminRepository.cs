using System;
using fbs_webApi_v2.Data;
using fbs_webApi_v2.DataModels;
using fbs_webApi_v2.DTOs.AdminDtos;

namespace fbs_webApi_v2.services.IRepositories
{
    public interface IAdminRepository
    {
        Task<serviceResponce<List<GetAdminDto>>> GetAllAdminsAsync();

        Task<serviceResponce<GetAdminDto>> GetAdminByIdAsync(int id);

        Task<serviceResponce<GetAdminDto>> GetAdminByEmailAsync(string email);

        Task<serviceResponce<GetAdminDto>> GetAdminByUsernameAsync(string username);

        Task<serviceResponce<List<GetAdminDto>>> AddAdminAsync(AddAdminDto newadmin);
        Task<serviceResponce<GetAdminDto>> UpdateAdminAsync(UpdateAdminDto updateadmin);

        Task<serviceResponce<List<GetAdminDto>>> DeleteAdminAsync(int id);

    }
}
