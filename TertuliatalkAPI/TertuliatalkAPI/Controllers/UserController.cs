using Microsoft.AspNetCore.Mvc;
using TertuliatalkAPI.Base;
using TertuliatalkAPI.Entities;
using TertuliatalkAPI.Exceptions;
using TertuliatalkAPI.Interfaces;

namespace TertuliatalkAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet]
    public async Task<ActionResult<ApiResponse<List<User>>>> GetUsers()
    {
        var response = await _userService.GetUsers();
        return Ok(new ApiResponse<List<User?>>(response));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ApiResponse<User>>> GetUser(Guid id)
    {
        var response = await _userService.GetUser(id);

        if (response == null)
            throw new NotFoundException($"User with ID {id} not found");

        return Ok(new ApiResponse<User>(response));
    }
}