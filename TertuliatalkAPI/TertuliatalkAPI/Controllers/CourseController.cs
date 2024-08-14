using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking;
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
    [Authorize]
    public async Task<ActionResult<ApiResponse<List<Course>>>> GetAllCourses()
    {
        var response = await _courseService.GetAllCourses();
        return Ok(new ApiResponse<List<Course>>(response));
    }

    [HttpGet("{id}")]
    [Authorize]
    public async Task<ActionResult<ApiResponse<Course>>> GetCourseById(Guid id)
    {
        var response = await _courseService.GetCourseById(id);
        return Ok(new ApiResponse<Course>(response));
    }

    [HttpPost("create-course")]
    [Authorize(Roles = Roles.Instructor)]
    public async Task<ActionResult<ApiResponse<EntityEntry<Course>>>> CreateCourse(
        [FromBody] CreateCourseRequest request)
    {
        Console.WriteLine();
        Console.WriteLine(User.FindFirst(ClaimTypes.Email)?.Value);
        Console.WriteLine();
        var response = await _courseService.CreateCourse(request);
        return Ok(new ApiResponse<Course>(response));
    }
}