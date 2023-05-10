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
        public async Task<IActionResult> Get()
        {
            var users =  await _userRepository.GetUsersAsync();
            return Ok(users);

        }

        [HttpPost]
        public async Task<IActionResult> AddUser(User user) 
        {
            if (ModelState.IsValid)
            {
                await _userRepository.CreateUserAsync(user);
                return Ok();
            }
            return StatusCode(500);
        }
    }
}
