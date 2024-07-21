using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using TertuliatalkAPI.Base;
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
        public async Task<ActionResult<ApiResponse<UserLoginResponse>>> LoginUser([FromBody] UserLoginRequest request)
        {
            var response =  await _authService.LoginUser(request);
            return Ok(new ApiResponse<UserLoginResponse>(response));
        }
        
        [HttpPost("register")]
        [AllowAnonymous]
        public async Task<ActionResult<ApiResponse<EntityEntry<User>>>> RegisterUser(User user)
        {
            var response = await _authService.RegisterUser(user);
            return Ok(new ApiResponse<EntityEntry<User>>(response));
        }
    }
}
