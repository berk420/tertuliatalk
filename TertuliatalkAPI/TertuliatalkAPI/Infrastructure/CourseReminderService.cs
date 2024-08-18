using Quartz;
using TertuliatalkAPI.Entities;

namespace TertuliatalkAPI.Infrastructure;

public class CourseReminderService : IJob
{
    private readonly TertuliatalksDbContext _context;
    private readonly ILogger<CourseReminderService> _logger;

    public CourseReminderService(TertuliatalksDbContext context, ILogger<CourseReminderService> logger)
    {
        _logger = logger;
        _context = context;
    }

    public Task Execute(IJobExecutionContext context)
    {
        throw new NotImplementedException();
    }
}