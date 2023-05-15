using System;
using System.Collections.Generic;
using fbs_webApi_v2.Data;
using fbs_webApi_v2.DataModels;
using Microsoft.EntityFrameworkCore;
using fbs_webApi_v2.services.IRepositories;
using fbs_webApi_v2.DTOs.AdminDtos;
using AutoMapper;

namespace fbs_webApi_v2.services.Repositories
{
    public class AdminRepository : IAdminRepository
    {
        private readonly fbscontext _context;
        private readonly IMapper _mapper;

        //controller
        public AdminRepository(fbscontext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<serviceResponce<List<GetAdminDto>>> AddAdminAsync(AddAdminDto newadmin)
        {

            //var checkadmin = await _context.Admins.FindAsync(newadmin.);
            //if (checkadmin == null)
            //{
            var responce = new serviceResponce<List<GetAdminDto>>();

            _context.Admins.Add(_mapper.Map<Admin>(newadmin));
            await _context.SaveChangesAsync();

            responce.Data = await _context.Admins.Select(a => _mapper.Map<GetAdminDto>(a)).ToListAsync();

            return responce;
            //}

            //return new serviceResponce<List<GetAdminDto>> { Success=false,Message="Check entered data"};
        }

        public async Task<serviceResponce<List<GetAdminDto>>> DeleteAdminAsync(int id)
        {
            var admin = await _context.Admins.FirstOrDefaultAsync(u => u.Id == id);

            serviceResponce<List<GetAdminDto>> responce = new serviceResponce<List<GetAdminDto>>();

            if (admin == null)
            {
                responce.Success = false;
                responce.Message = "admin not found";
                return responce;
            };

            _context.Admins.Remove(admin);

            await _context.SaveChangesAsync();
            responce.Message = "admin removed";
            return responce;
        }


        public async Task<serviceResponce<GetAdminDto>> GetAdminByEmailAsync(string email)
        {
            var admin = await _context.Admins.FirstOrDefaultAsync(u => u.Email_Id == email);
            if (admin == null)
            {
                var adminobj = _mapper.Map<GetAdminDto>(admin);
                return new serviceResponce<GetAdminDto> { Data = adminobj };
            }
            return new serviceResponce<GetAdminDto> { Success = false, Message = "Admin not found" };
        }

        public async Task<serviceResponce<GetAdminDto>> GetAdminByIdAsync(int id)
        {
            var admin = await _context.Admins.FirstOrDefaultAsync(u => u.Id == id);
            if (admin != null)
            {
                var adminobj = _mapper.Map<GetAdminDto>(admin);
                return new serviceResponce<GetAdminDto> { Data = adminobj };
            }
            return new serviceResponce<GetAdminDto> { Success = false, Message = "Admin not found" };
        }

        public async Task<serviceResponce<GetAdminDto>> GetAdminByUsernameAsync(string adminname)
        {
            var admin = await _context.Admins.FirstOrDefaultAsync(u => u.Admin_Name == adminname);
            if (admin == null)
            {
                var adminobj = _mapper.Map<GetAdminDto>(admin);
                return new serviceResponce<GetAdminDto> { Data = adminobj };
            }
            return new serviceResponce<GetAdminDto> { Success = false, Message = "Admin not found" };
        }

        public async Task<serviceResponce<List<GetAdminDto>>> GetAllAdminsAsync()
        {
            var responce = new serviceResponce<List<GetAdminDto>>();

            var admins = await _context.Admins.ToListAsync();
            responce.Data = admins.Select(a => _mapper.Map<GetAdminDto>(a)).ToList();
            return responce;
        }

        public async Task<serviceResponce<GetAdminDto>> UpdateAdminAsync(UpdateAdminDto updateadmin)
        {
            Admin adminupdate = await _context.Admins.FindAsync(updateadmin.Admin_Id);

            serviceResponce<GetAdminDto> responce = new serviceResponce<GetAdminDto>();

            if (adminupdate != null)
            {

                _mapper.Map(updateadmin, adminupdate);
                //adminupdate.Admin_Name = updateadmin.Admin_Name;
                //adminupdate.Email_Id = updateadmin.Email_Id;

                await _context.SaveChangesAsync();
                responce.Data = _mapper.Map<GetAdminDto>(adminupdate);
                responce.Message = "update Completed";
                return responce;
            }
            responce.Success = false;
            responce.Message = "update not done, user not found";
            return responce;

        }
    }
}
