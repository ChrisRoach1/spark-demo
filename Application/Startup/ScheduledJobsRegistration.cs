using spark_demo.Application.Jobs;
using Coravel;

namespace spark_demo.Application.Startup;

public static class ScheduledJobsRegistration
{
    public static IServiceProvider SetupScheduledJobs(this IServiceProvider services)
    {
        services.UseScheduler(scheduler =>
        {
            // example scheduled job
            //scheduler
            //    .Schedule<ExampleJob>()
            //    .EveryFiveMinutes();
        });
        return services;
    }
}
