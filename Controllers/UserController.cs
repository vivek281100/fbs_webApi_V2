using System;
using fbs_webApi_v2.IRepositories;
using fbs_webApi_v2.DataModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace fbs_webApi_v2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet]
        [Route("users")]
        public async Task<IActionResult> Getusers()
        {
            var users =  await _userRepository.GetUsersAsync();
            if (users != null)
            {
                return Ok(users);
            }

            return BadRequest("no users found 😢");

        }

        [HttpGet]
        [Route("usersById")]
        public async Task<IActionResult> getUserById(int id)
        {
            var user = await _userRepository.GetUserByUser_IdAsync(id);
            if (user != null)
            {
                return Ok(user);
            }

            return BadRequest("no user found 😢");
        }

        [HttpGet]
        [Route("usersByEmail")]
        public async Task<IActionResult> getUserByEmail(string email) 
        {
            var user = await _userRepository.GetUserByUser_EmailAsync(email);
            if (user != null)
            {
                return Ok(user);
            }

            return BadRequest("no user found 😢");
        }

        [HttpGet]
        [Route("usersByUserName")]
        public async Task<IActionResult> getUserByUsername(string username) 
        {
            var user = await _userRepository.GetUserByUser_NameAsync(username);
            if (user != null)
            {
                return Ok(user);
            }

            return BadRequest("no user found 😢");
        }


        [HttpGet]
        [Route("usersByPhonenumber")]
        public async Task<IActionResult> getUserByPhonenumber(string phonenumber)
        {
            var user = await _userRepository.GetUserByPhonenumberAsync(phonenumber);
            if (user != null)
            {
                return Ok(user);
            }

            return BadRequest("no user found 😢");
        }

        [HttpPost]
        [Route("Addusers")]
        public async Task<IActionResult> AddUser(User user) 
        {
            if (ModelState.IsValid)
            {
                await _userRepository.CreateUserAsync(user);
                return Ok();
            }
            return StatusCode(500);
        }

        [HttpPut]
        [Route("Updateusers")]
        public async Task<IActionResult> updateUser(User user)
        {
            if (ModelState.IsValid) 
            {
                var userupdate = await _userRepository.UpdateUserAsync(user);
                if (!userupdate)
                { 
                    return BadRequest("operation failed , try again after sometime"); 
                };

                return Ok("User Updated");
            }

            return StatusCode(500,"user details not valid");
        }

        [HttpDelete]
        [Route("Deleteusers")]
        public async Task<IActionResult> deleteUser(int id)
        {
            var checkdelete = await _userRepository.DeleteUserAsync(id);
            if(!checkdelete)
            {
                return BadRequest("operation failed , try again after sometime");
            }

            return Ok("Done!");
        }
    }
}
