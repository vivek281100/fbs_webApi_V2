using fbs_webApi_v2.DataModels;
using fbs_webApi_v2.services.Repositories;
using fbs_webApi_v2.services.IRepositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using fbs_webApi_v2.Data;
using fbs_webApi_v2.DTOs.AdminDtos;
using Microsoft.AspNetCore.Authorization;

namespace fbs_webApi_v2.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IAdminRepository _adminRepository;

        //controller
        public AdminController(IAdminRepository adminRepository)
        {
            _adminRepository = adminRepository;
        }

        [HttpGet]
        [Route("admins")]
        public async Task<ActionResult<serviceResponce<List<GetAdminDto>>>> Getadmins()
        {
            var admin = await _adminRepository.GetAllAdminsAsync();
            if (admin != null)
            {
                return Ok(admin);
            }

            return BadRequest("no users found 😢");

        }

        [HttpGet]
        [Route("adminsbyid/{id}")]
        public async Task<ActionResult<serviceResponce<GetAdminDto>>> getadminbyid(int id)
        {
            var admin = await _adminRepository.GetAdminByIdAsync(id);
            if (admin != null)
            {
                return Ok(admin);
            }

            return BadRequest("no user found 😢");
        }

        [HttpGet]
        [Route("adminsByEmail/{email}")]
        public async Task<ActionResult<serviceResponce<GetAdminDto>>> getadminByEmail(string email)
        {
            var admin = await _adminRepository.GetAdminByEmailAsync(email);
            if (admin != null)
            {
                return Ok(admin);
            }

            return BadRequest("no user found 😢");
        }

        [HttpGet]
        [Route("adminsByUserName/{username}")]
        public async Task<ActionResult<serviceResponce<GetAdminDto>>> getAdminByUsername(string username)
        {
            var admin = await _adminRepository.GetAdminByUsernameAsync(username);
            if (admin.Success)
            {
                return Ok(admin);
            }

            return BadRequest("no user found 😢");
        }


        [HttpPost]
        [Route("Addadmins")]
        public async Task<ActionResult<serviceResponce<List<GetAdminDto>>>> AddAdmin(AddAdminDto admin)
        {
            if (ModelState.IsValid)
            {
                await _adminRepository.AddAdminAsync(admin);
                return Ok("admin added");
            }
            return StatusCode(500);
        }

        [HttpPut]
        [Route("Updateadmins")]
        public async Task<ActionResult<serviceResponce<GetAdminDto>>> updateUser(UpdateAdminDto updateadmin)
        {
            if (ModelState.IsValid)
            {
                var adminupdate = await _adminRepository.UpdateAdminAsync(updateadmin);
                if (adminupdate.Success)
                {
                    return Ok("User Updated, " + adminupdate.Success);
                };

                return BadRequest(adminupdate.Message);
            }

            return StatusCode(500, "enter valid data");
        }

        [HttpDelete]
        [Route("Deleteadmins/{id}")]
        public async Task<ActionResult<serviceResponce<List<GetAdminDto>>>> deleteAdmin(int id)
        {
            var checkdelete = await _adminRepository.DeleteAdminAsync(id);
            if (checkdelete.Success)
            {
                return BadRequest(checkdelete.Message);
            }

            return Ok("Done!");
        }
    }
}
