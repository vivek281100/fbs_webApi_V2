using fbs_webApi_v2.Data;
using fbs_webApi_v2.DTOs.AuthDtos;
using fbs_webApi_v2.services.Authservice;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace fbs_webApi_v2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IAuthRepository _authRepo;

        public AuthController(IAuthRepository auth)
        {
            _authRepo = auth;
        }

        [HttpPost]
        [Route("authRegisterUser")]
        public async Task<ActionResult<serviceResponce<int>>> Register(UserRegisterDto request)
        {
            var responce = await _authRepo.Register(
                new DataModels.User { User_Name =  request.UserName ,Email = request.email,PhoneNumber = request.phonenumber}, request.Password
                );
            if(!responce.Success)
            {
                return BadRequest(responce);
            }

            return Ok(responce);
        }


        [HttpPost]
        [Route("authUserLogin")]
        public async Task<ActionResult<serviceResponce<int>>> Login(UserLoginDto request)
        {
            var responce = await _authRepo.Login(request.username,request.Password);
            if (!responce.Success)
            {
                return BadRequest(responce);
            }

            return Ok(responce);
        }
    }
}
