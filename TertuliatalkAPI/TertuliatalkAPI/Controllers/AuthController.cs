using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TertuliatalkAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        /*

        private readonly UserManager<User> _userManager;

        public AuthController(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        */

        [HttpPost("signup")]
        public async Task<IActionResult> SignUp(SignUpDto signUpDto)
        {
            if (signUpDto == null)
            {
                return BadRequest("Invalid user data.");
            }

            var user = new User
            {
                Email = signUpDto.Email,
                Password = signUpDto.Password,
            };

            return Ok(user); 
        }
    }
}

