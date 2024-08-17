using Microsoft.EntityFrameworkCore;
using TertuliatalkAPI.Entities;
using TertuliatalkAPI.Exceptions;
using TertuliatalkAPI.Interfaces;
using TertuliatalkAPI.Models;

namespace TertuliatalkAPI.Services;

public class CourseService : ICourseService
{
    private readonly IAuthService _authService;
    private readonly IUserService _userService;
    private readonly TertuliatalksDbContext _context;
    private readonly ILogger<CourseService> _logger;

    public CourseService(TertuliatalksDbContext context, ILogger<CourseService> logger, IAuthService authService, IUserService userService)
    {
        _context = context;
        _logger = logger;
        _authService = authService;
        _userService = userService;
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

    public Task<List<Course>> GetCoursesByDateRange(DateTime startDate, DateTime endDate)
    {
        
        var utcStartDate = DateTime.SpecifyKind(startDate, DateTimeKind.Utc);
        var utcEndDate = DateTime.SpecifyKind(endDate, DateTimeKind.Utc);

        return _context.Courses
            .Where(course => course.StartDate >= utcStartDate && course.StartDate <= utcEndDate)
            .ToListAsync();
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
            request.StartDate,
            request.Duration,
            // request.Document,
            instructor.Id
        );
        
        var newCourse = _context.Courses.Add(course).Entity;
        await _context.SaveChangesAsync();

        return newCourse;
    }

    public async Task DeleteCourse(Guid courseId)
    {
        var instructor = await _authService.GetLoggedInstructor();

        var course = await this.GetCourseById(courseId);

        if (course.InstructorId != instructor.Id)
            throw new UnauthorizedException("You are not authorized to access this course.");

        _context.Courses.Remove(course);
        await _context.SaveChangesAsync();
    }

    public async Task<bool> HasUserJoinedInCourse(Guid courseId, Guid userId)
    {
        var user = await _userService.GetUser(userId);
        foreach (var userCourse in user.UserCourses)
        {
            if (userCourse.CourseId == courseId)
                return true;
        }
        return false;
    }

    public async Task<Course> AddUserToCourse(Guid courseId)
    {
        var user = await _authService.GetLoggedUser();
        
        var course = await this.GetCourseById(courseId);

        var hasJoinedCourse = await this.HasUserJoinedInCourse(course.Id, user.Id);
        if (hasJoinedCourse)
            throw new InvalidOperationException("User is already join in this course.");

        var userCourse = new UserCourse
        {
            UserId = user.Id,
            CourseId = course.Id,
        };
        
        _context.UserCourses.Add(userCourse);
        
        course.Participants++;
        await _context.SaveChangesAsync();

        return course;
    }

    public async Task<Course> RemoveUserToCourse(Guid courseId)
    {
        var user = await _authService.GetLoggedUser();
        
        var course = await this.GetCourseById(courseId);
        
        var hasJoinedCourse = await this.HasUserJoinedInCourse(course.Id, user.Id);
        if (!hasJoinedCourse)
            throw new InvalidOperationException("User is not in the this course.");

        var userCourse = await _context.UserCourses.FirstOrDefaultAsync(uc => uc.UserId == user.Id && uc.CourseId == course.Id);

        _context.UserCourses.Remove(userCourse);
        
        course.Participants--;
        await _context.SaveChangesAsync();

        return course;
    }
}