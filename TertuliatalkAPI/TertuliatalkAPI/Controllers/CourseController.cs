using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TertuliatalkAPI.Base;
using TertuliatalkAPI.Entities;
using TertuliatalkAPI.Interfaces;
using TertuliatalkAPI.Models;

namespace TertuliatalkAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CourseController : ControllerBase
{
    private readonly ICourseService _courseService;

    public CourseController(ICourseService courseService)
    {
        _courseService = courseService;
    }

    [HttpGet]
    [AllowAnonymous] // change with JWT
    // [Authorize(Roles = Roles.Instructor)]
    public async Task<ActionResult<ApiResponse<List<Course>>>> GetAllCourses()
    {
        var response = await _courseService.GetAllCourses();
        return Ok(new ApiResponse<List<Course>>(response));
    }

    [HttpGet("{id}")]
    [AllowAnonymous] // change with JWT
    // [Authorize(Roles = Roles.Instructor)]
    public async Task<ActionResult<ApiResponse<Course>>> GetCourseById(Guid id)
    {
        var response = await _courseService.GetCourseById(id);
        return Ok(new ApiResponse<Course>(response));
    }
}