using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ReportingService.CleaningHouse
{
    internal class Scheduler
    {
        public static List<Timer> timers;

        public static void Run(Action task, int stsrtMinute, double hourlyInterval)
        {
            timers ??= new List<Timer>();
            var timer = new Timer(x => task.Invoke(), null, TimeSpan.FromMinutes(stsrtMinute) , TimeSpan.FromHours(hourlyInterval));
            timers.Add(timer);
        }
    }
}
