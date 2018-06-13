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
            // khởi tạo 1 sẽ làm việc sendemaildaily
            IJobDetail job = JobBuilder.Create<SendEmailDaily>().Build();


            //thêm trigger
            ITrigger trigger = TriggerBuilder.Create()

                .WithDailyTimeIntervalSchedule

                  (s =>

                     s.WithIntervalInHours(24) // việc sẽ làm sau 24h

                    .OnEveryDay() // vào mỗi ngày

                    .StartingDailyAt(TimeOfDay.HourAndMinuteOfDay(14,17)) //bắt đầu lúc 14:17

                  )

                .Build();



            scheduler.ScheduleJob(job, trigger); //set việc
        }
    }
}