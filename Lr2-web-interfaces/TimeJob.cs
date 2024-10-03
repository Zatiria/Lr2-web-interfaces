using Quartz;
using Quartz.Impl;

namespace Lr2_web_interfaces
{
    internal class TimeJob : IJob
    {
        public Task Execute(IJobExecutionContext context)
        {
            Console.WriteLine("Час: " + DateTime.Now);
            return Task.CompletedTask;
        }

        public static async Task QuartzExample()
        {
            IScheduler scheduler = await StdSchedulerFactory.GetDefaultScheduler();
            await scheduler.Start();

            IJobDetail job = JobBuilder.Create<TimeJob>().Build();

            ITrigger trigger = TriggerBuilder.Create()
                .WithIdentity("trigger1", "group1")
                .StartNow()
                .WithSimpleSchedule(x => x
                    .WithIntervalInSeconds(5)
                    .RepeatForever())
                .Build();

            await scheduler.ScheduleJob(job, trigger);

            Console.WriteLine("Натисніть Enter для завершення...");
            Console.ReadLine();
            await scheduler.Shutdown();
        }
    }
}
