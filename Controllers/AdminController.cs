using fbs_webApi_v2.DataModels;
using fbs_webApi_v2.services.Repositories;
using fbs_webApi_v2.services.IRepositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using fbs_webApi_v2.Data;
using fbs_webApi_v2.DTOs.AdminDtos;
using Microsoft.AspNetCore.Authorization;
using fbs_webApi_v2.DTOs.UserDtos;

namespace fbs_webApi_v2.Controllers
{
    [Authorize]
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

        #region admin actions for admin

        #region get admins
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
        #endregion


        #region get admin by id
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
        #endregion

        #region get admin by email
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
        #endregion

        #region get admin by username

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
        #endregion

        #region Add Admin
        [HttpPost]
        [Route("Addadmins")]
        public async Task<ActionResult<serviceResponce<List<GetAdminDto>>>> AddAdmin(AddAdminDto admin)
        {
            if (ModelState.IsValid)
            {
               
                return Ok("admin added");
            }
            return StatusCode(500);
        }
        #endregion

        #region (update admin)
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
        #endregion

        #region delete admin

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

        #endregion

        #endregion

        /// based on new design ///

        #region admin actions for users


        #region get users
        [HttpGet]
        [Route("GetUsers")]
        public async Task<IActionResult> getUsers()
        {
            try
            {
                var responce = await _adminRepository.GetAllUsersAsync();
                return Ok(responce);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        #endregion


        #region update user
        [HttpPut]
        [Route("updateUser")]
        public async Task<IActionResult> updateUser(updateUserDto userupdate)
        {
            try
            {
                var responce = await _adminRepository.updateUserAsync(userupdate);
                return Ok(responce);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        #endregion


        #region delete user

        [HttpDelete]
        [Route("deleteUser")]
        public async Task<IActionResult> deleteUser(int id)
        {
            try
            {
                var responce = await _adminRepository.DeleteUserAsync(id);
                return Ok(responce);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }



        #endregion


        #endregion
    }
}
