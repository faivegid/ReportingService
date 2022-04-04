using Microsoft.Extensions.DependencyInjection;
using ReportingService.CleaningHouse.CleaningService.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportingService.CleaningHouse
{
    internal class Function
    {
        public static void Run()
        {
            Scheduler.Run(async () => await RunTwelveHourCleanUp(), 0, 1);
        }

        private static async Task RunTwelveHourCleanUp()
        {
            var scope = Program.CreateScope();
            await scope.ServiceProvider.GetService<ITwelveHourCleaning>().PerFormCleanUp();
        }
    }
}
