using System;
using fbs_webApi_v2.DataModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using fbs_webApi_v2.services.IRepositories;
using fbs_webApi_v2.Data;
using fbs_webApi_v2.services.Authservice;
using fbs_webApi_v2.DTOs.UserDtos;
using fbs_webApi_v2.DTOs.AuthDtos;
using fbs_webApi_v2.DataModels;
//using fbs_webApi_v2.Controllers;
using Microsoft.AspNetCore.Authorization;

namespace fbs_webApi_v2.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IAuthRepository _authRepository;


        public UserController(IUserRepository userRepository, IAuthRepository authRepository)
        {
            _userRepository = userRepository;
            _authRepository = authRepository;
            
        }
        #region (Previous Methods)
        //[HttpGet]
        //[Route("users")]
        //public async Task<ActionResult<serviceResponce<List<GetUserDto>>>> Getusers()
        //{
        //    var responce = await _userRepository.GetUsersAsync();
        //    if (responce.Success)
        //    {
        //        responce.Message = "Users Retrevied";
        //        return Ok(responce);
        //    }

        //    responce.Message = "List Empty";
        //    return BadRequest(responce.Message);

        //}

        //[HttpGet]
        //[Route("usersById/{id}")]
        //public async Task<ActionResult<serviceResponce<GetUserDto>>> getUserById(int id)
        //{
        //    var responce = await _userRepository.GetUserByUser_IdAsync(id);
        //    if (responce.Success)
        //    {
        //        return Ok(responce);
        //    }
        //    responce.Message = "User not found";
        //    return BadRequest(responce);
        //}

        //[HttpGet]
        //[Route("usersByEmail/{email}")]
        //public async Task<IActionResult> getUserByEmail(string email)
        //{
        //    var user = await _userRepository.GetUserByUser_EmailAsync(email);
        //    if (user != null)
        //    {
        //        return Ok(user);
        //    }

        //    return BadRequest("no user found 😢");
        //}

        //[HttpGet]
        //[Route("usersByUserName/{username}")]
        //public async Task<IActionResult> getUserByUsername(string username)
        //{
        //    var user = await _userRepository.GetUserByUserNameAsync(username);
        //    if (user != null)
        //    {
        //        return Ok(user);
        //    }

        //    return BadRequest("no user found 😢");
        //}


        //[HttpGet]
        //[Route("usersByPhonenumber/{phonenumber}")]
        //public async Task<IActionResult> getUserByPhonenumber(string phonenumber)
        //{
        //    var user = await _userRepository.GetUserByPhonenumberAsync(phonenumber);
        //    if (user != null)
        //    {
        //        return Ok(user);
        //    }

        //    return BadRequest("no user found 😢");
        //}
        #endregion

        [HttpPost]
        [Route("UserLogin")]
        [AllowAnonymous]
        //from AuthRepository.
        public async Task<IActionResult> Login(UserLoginDto details)
        {
            try
            {
                var responce = await _authRepository.Login(details.username, details.Password);
                return Ok(responce);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("registeruser")]
        [AllowAnonymous]
        // From AuthRepository.
        public async Task<ActionResult<serviceResponce<GetUserDto>>> Register(UserRegisterDto registeruser)
        {
            try
            {
                var responce = await _authRepository.Register(
                    new User() { User_Name = registeruser.UserName, Email = registeruser.UserName, PhoneNumber = registeruser.phonenumber }, registeruser.Password);
                    return Ok(responce);
                
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        [HttpPut]
        [Route("Updateusers")]
        public async Task<ActionResult> updateUser(updateUserDto updateuser)
        {
            if (ModelState.IsValid)
            {
                var userupdate = await _userRepository.UpdateUserAsync(updateuser);
                if (!userupdate.Success)
                {
                    return BadRequest(userupdate);
                };

                return Ok(userupdate);
            }

            return StatusCode(500, "user details not valid");
        }

        [HttpDelete]
        [Route("Deleteusers/{id}")]
        public async Task<IActionResult> deleteUser(int id)
        {
            var checkdelete = await _userRepository.DeleteUserAsync(id);
            if (!checkdelete.Success)
            {
                return BadRequest(checkdelete);
            }

            return Ok(checkdelete);
        }
    }
}
