using Microsoft.EntityFrameworkCore;
using TertuliatalkAPI.Entities;
using TertuliatalkAPI.Infrastructure.Interfaces;
using TertuliatalkAPI.Infrastructure.Repositories.Interfaces;

namespace TertuliatalkAPI.Infrastructure.Repositories;

public class CourseRepository : ICourseRepository
{
    private readonly IRedisCacheService _cacheService;
    private readonly TertuliatalksDbContext _context;

    public CourseRepository(TertuliatalksDbContext context, IRedisCacheService cacheService)
    {
        _context = context;
        _cacheService = cacheService;
    }

    public async Task<List<Course>> GetAllCoursesAsync()
    {
        var cachedCourses = await _cacheService.GetAsync<List<Course>>("allCourses");

        if (cachedCourses != null) return cachedCourses;

        var courses = await _context.Courses.Include(c => c.UserCourses).ToListAsync();
        await _cacheService.SetAsync("allCourses", courses, TimeSpan.FromDays(1));

        return courses;
    }

    public async Task<Course?> GetCourseByIdAsync(Guid courseId)
    {
        return await _context.Courses.Include(c => c.Instructor).Include(c => c.UserCourses)
            .FirstOrDefaultAsync(c => c.Id == courseId);
    }

    public async Task<List<Course>> GetCoursesByDateRangeAsync(DateTime startDate, DateTime endDate)
    {
        var courses = await _context.Courses
            .Where(course => course.StartDate >= startDate && course.StartDate <= endDate).ToListAsync();

        return courses;
    }

    public async Task<Course> AddCourseAsync(Course course)
    {
        var newCourse = _context.Courses.Add(course).Entity;
        await _context.SaveChangesAsync();
        
        await _cacheService.RemoveAsync("allCourses");
        
        return newCourse;
    }

    public async Task UpdateCourseAsync(Course course)
    {
        _context.Courses.Update(course);
        await _context.SaveChangesAsync();
        
        await _cacheService.RemoveAsync("allCourses");
    }

    public async Task DeleteCourseAsync(Course course)
    {
        _context.Courses.Remove(course);
        await _context.SaveChangesAsync();
        
        await _cacheService.RemoveAsync("allCourses");
    }
}