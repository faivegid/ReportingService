using ReportingService.Data.Repository.Contracct;
using ReportingService.Modela.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportingService.Data.Repository.Implementation
{
    public class ActivityRepository : IActivityRepository
    {
        public ActivityRepository()
        {
        }

        public async Task AddValueToActivityStoresAsync(ActivityDTO dTO)
        {
            await ActivityStores.AddActivityAsync(dTO);
        }

        public async Task<int> GetSumOfActivityValues(string key)
        {
            return await ActivityStores.GetTwekveHourTaskValueSum(key);
        }
    }
}
