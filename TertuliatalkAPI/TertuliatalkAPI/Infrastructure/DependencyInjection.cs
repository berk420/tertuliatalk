using Quartz;

namespace TertuliatalkAPI.Infrastructure;

public static class DependencyInjection
{
    public static void AddInfrastructure(this IServiceCollection services)
    {
        services.AddQuartz(options =>
        {
            var jobKey = JobKey.Create(nameof(CourseStatusUpdaterService));

            options.UseMicrosoftDependencyInjectionJobFactory();

            options
                .AddJob<CourseStatusUpdaterService>(jobKey)
                .AddTrigger(trigger =>
                    trigger
                        .ForJob(jobKey)
                        .WithSimpleSchedule(schedule =>
                            schedule.WithIntervalInSeconds(60).RepeatForever()));
        });

        services.AddQuartzHostedService();
    }
}