using Microsoft.EntityFrameworkCore;
using TertuliatalkAPI.Entities;
using TertuliatalkAPI.Exceptions;
using TertuliatalkAPI.Interfaces;

namespace TertuliatalkAPI.Services;

public class CourseService : ICourseService
{
    private readonly TertuliatalksDbContext _context;
    private readonly ILogger<CourseService> _logger;

    public CourseService(TertuliatalksDbContext context, ILogger<CourseService> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task<IEnumerable<Course>> GetAllCourses()
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

    public async Task<Course> CreateCourse(Course course)
    {
        throw new NotImplementedException();
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