using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Quartz;
using Quartz.Impl;

namespace ServeyEmail.Models
{
    public class SetUpScheduler
    {
        public static void start()
        {
            IScheduler scheduler = StdSchedulerFactory.GetDefaultScheduler();

            scheduler.Start();



            IJobDetail job = JobBuilder.Create<SendEmailDaily>().Build();



            ITrigger trigger = TriggerBuilder.Create()

                .WithDailyTimeIntervalSchedule

                  (s =>

                     s.WithIntervalInHours(24)

                    .OnEveryDay()

                    .StartingDailyAt(TimeOfDay.HourAndMinuteOfDay(13,55))

                  )

                .Build();



            scheduler.ScheduleJob(job, trigger);
        }
    }
}