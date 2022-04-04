using Microsoft.EntityFrameworkCore;
using ReportingService.Modela.Domain;
using ReportingService.Modela.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReportingService.Data

{
    public class ActivityStores : DbContext
    {
        public static string CONNECTIONSTRING => "Data Source=ActivityStores";

        public DbSet<Activity> Activities { get; set; }
        public DbSet<ActivityValue> ActiivityValues { get; set; }


        public ActivityStores(DbContextOptions options) : base(options)
        {
        }

    }
}
