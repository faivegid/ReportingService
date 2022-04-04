using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using ReportingService.CleaningHouse.CleaningService.Contract;
using ReportingService.CleaningHouse.CleaningService.IMplementaiton;
using ReportingService.Data;
using ReportingService.Data.Repository.Contracct;
using ReportingService.Data.Repository.Implementation;
using System;

namespace ReportingService.CleaningHouse
{
    internal class Program
    {
        public static IHost Host { get; private set; }

        static void Main(string[] args)
        {
            var builder = new HostBuilder();

            builder.ConfigureContainer((ServiceCollection services) => ConfigureService(services));
            builder.ConfigureLogging((ILoggingBuilder logging) => logging.AddConsole());

            Host = builder.Build();

            Function.Run();

            using (Host)
            {
                Host.Run();
            }
        }

        private static void ConfigureService(ServiceCollection services)
        {
            services.AddDbContext<ActivityStores>(options =>
               options.UseSqlite(ActivityStores.CONNECTIONSTRING));
            services.AddScoped<IActivityRepository, ActivityRepository>();
            services.AddScoped<ITwelveHourCleaning, TwelveHourCleaning>();
        }

        public static IServiceScope CreateScope()
        {
            return Host.Services.CreateScope();
        }
    }
}
