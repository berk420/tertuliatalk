using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using TertuliatalkAPI.Entities;
using TertuliatalkAPI.Interfaces;
using TertuliatalkAPI.Models;

namespace TertuliatalkAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<ActionResult<UserLoginResponse>> LoginUser([FromBody] UserLoginRequest request)
        {
            return await _authService.LoginUser(request);
        }
        
        [HttpPost("register")]
        [AllowAnonymous]
        public async Task<EntityEntry<User>> RegisterUser(User user)
        {
            return await _authService.RegisterUser(user);
        }
    }
}
