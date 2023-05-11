using fbs_webApi_v2.DataModels;
using fbs_webApi_v2.IRepositories;
using fbs_webApi_v2.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace fbs_webApi_v2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IAdminRepository _adminRepository;

        public AdminController(IAdminRepository adminRepository)
        {
            _adminRepository = adminRepository;
        }

        [HttpGet]
        [Route("admins")]
        public async Task<IActionResult> Getadmins()
        {
            var admin = await _adminRepository.GetAllAdminsAsync();
            if (admin != null)
            {
                return Ok(admin);
            }

            return BadRequest("no users found 😢");

        }

        [HttpGet]
        [Route("adminsById")]
        public async Task<IActionResult> getadminById(int id)
        {
            var admin = await _adminRepository.GetAdminByIdAsync(id);
            if (admin != null)
            {
                return Ok(admin);
            }

            return BadRequest("no user found 😢");
        }

        [HttpGet]
        [Route("adminsByEmail")]
        public async Task<IActionResult> getadminByEmail(string email)
        {
            var admin = await _adminRepository.GetAdminByEmailAsync(email);
            if (admin != null)
            {
                return Ok(admin);
            }

            return BadRequest("no user found 😢");
        }

        [HttpGet]
        [Route("adminsByUserName")]
        public async Task<IActionResult> getAdminByUsername(string username)
        {
            var admin = await _adminRepository.GetAdminByUsernameAsync(username);
            if (admin != null)
            {
                return Ok(admin);
            }

            return BadRequest("no user found 😢");
        }


        [HttpPost]
        [Route("Addadmins")]
        public async Task<IActionResult> AddAdmin(Admin admin)
        {
            if (ModelState.IsValid)
            {
                await _adminRepository.AddAdminAsync(admin);
                return Ok();
            }
            return StatusCode(500);
        }

        [HttpPut]
        [Route("Updateadmins")]
        public async Task<IActionResult> updateUser(Admin admin)
        {
            if (ModelState.IsValid)
            {
                var adminupdate = await _adminRepository.UpdateAdminAsync(admin);
                if (!adminupdate)
                {
                    return BadRequest("operation failed , try again after sometime");
                };

                return Ok("User Updated");
            }

            return StatusCode(500, "user details not valid");
        }

        [HttpDelete]
        [Route("Deleteadmins")]
        public async Task<IActionResult> deleteUser(int id)
        {
            var checkdelete = await _adminRepository.DeleteAdminAsync(id);
            if (!checkdelete)
            {
                return BadRequest("operation failed , try again after sometime");
            }

            return Ok("Done!");
        }
    }
}
