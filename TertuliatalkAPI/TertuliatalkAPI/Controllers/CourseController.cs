using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TertuliatalkAPI.Entities;
using TertuliatalkAPI.Interfaces;

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
    public async Task<ActionResult<Course>> GetAllCourses()
    {
        var response = await _courseService.GetAllCourses();
        return Ok(response);
    }

    [HttpGet("{id}")]
    [AllowAnonymous] // change with JWT
    public async Task<ActionResult<Course>> GetCourseById(Guid id)
    {
        var response = await _courseService.GetCourseById(id);
        return Ok(response);
    }
}