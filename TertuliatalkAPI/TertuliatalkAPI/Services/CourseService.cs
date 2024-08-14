using Microsoft.EntityFrameworkCore;
using TertuliatalkAPI.Entities;
using TertuliatalkAPI.Exceptions;
using TertuliatalkAPI.Interfaces;
using TertuliatalkAPI.Models;

namespace TertuliatalkAPI.Services;

public class CourseService : ICourseService
{
    private readonly IAuthService _authService;
    private readonly TertuliatalksDbContext _context;
    private readonly ILogger<CourseService> _logger;

    public CourseService(TertuliatalksDbContext context, ILogger<CourseService> logger, IAuthService authService)
    {
        _context = context;
        _logger = logger;
        _authService = authService;
    }

    public async Task<List<Course>> GetAllCourses()
    {
        return await _context.Courses.Include(c => c.Instructor).Include(c => c.UserCourses).ToListAsync();
    }

    public async Task<Course> GetCourseById(Guid courseId)
    {
        var course = await _context.Courses.Include(c => c.Instructor).Include(c => c.UserCourses)
            .FirstOrDefaultAsync(c => c.Id == courseId);
        if (course == null)
            throw new NotFoundException($"Course with ID {courseId} not found");

        return course;
    }

    public async Task<Course> CreateCourse(CreateCourseRequest request)
    {
        var instructor = await _authService.GetLoggedInstructor();

        var course = new Course(
            request.Title,
            request.Description,
            request.Type,
            request.Participants,
            request.MaxParticipants,
            instructor.Id
        );
        
        var newCourse = _context.Courses.Add(course).Entity;
        await _context.SaveChangesAsync();

        return newCourse;
    }

    public async Task DeleteCourse(Guid courseId)
    {
        throw new NotImplementedException();
    }

    public async Task<Course> AddUserToCourse(Guid courseId)
    {
        throw new NotImplementedException();
    }

    public async Task<Course> RemoveUserToCourse(Guid courseId)
    {
        throw new NotImplementedException();
    }
}