using LinqToDB;
using Quartz;
using TertuliatalkAPI.Entities;

namespace TertuliatalkAPI.Infrastructure;

public class CourseStatusUpdaterService : IJob
{
    private readonly TertuliatalksDbContext _context;
    private readonly ILogger<CourseStatusUpdaterService> _logger;

    public CourseStatusUpdaterService(TertuliatalksDbContext context, ILogger<CourseStatusUpdaterService> logger)
    {
        _logger = logger;
        _context = context;
    }

    public async Task Execute(IJobExecutionContext context)
    {
        var now = DateTime.UtcNow;

        var courses = await _context.Courses
            .Where(c => c.StartDate <= now && c.Status == "Active")
            .ToListAsync();

        if (courses.Count > 0)
        {
            foreach (var course in courses)
            {
                course.Status = "Started";
                course.UpdatedDate = DateTime.UtcNow;

                _logger.LogInformation($"Course {course.Id} updated status.");
            }
            await _context.SaveChangesAsync();
        }
    }
}