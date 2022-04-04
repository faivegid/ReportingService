using Microsoft.EntityFrameworkCore;
using ReportingService.Data.Repository.Contracct;
using ReportingService.Modela.Domain;
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
        private readonly ActivityStores _activityStores;
        public ActivityRepository(ActivityStores activityStores)
        {
            _activityStores = activityStores;
        }

        public async Task AddValueToActivityStoresAsync(ActivityDTO dTO)
        {
            var activity = await _activityStores.Activities.FirstOrDefaultAsync(a => a.Id == dTO.Id);

            if (activity == null)
            {
                activity = new Activity(dTO.Id, dTO.Value);
                _activityStores.Activities.Add(activity);
            }
            else
            {
                activity.AddValue(dTO.Value);
                _activityStores.Update(activity);
            }

            await _activityStores.SaveChangesAsync();
        }

        public async Task<int> GetSumOfActivityValues(string key)
        {
            var activity = await _activityStores.Activities.Include(x =>x.Values)
                                            .FirstOrDefaultAsync(a => a.Id == key);

            var date = DateTime.Now.AddHours(-12);

            if (activity == null)
                return 0;
            else
                return activity.Values.Where(x => x.InsertedTimeStamp >= date).Sum(x => x.Value);
        }



        /// <summary>
        /// Cleans all values inserted 12 hours ago
        /// </summary>
        /// <returns></returns>
        internal static async Task RunCLeanUp()
        {
            await Task.Run(() =>
            {
                
            });
        }
        public async Task RunactivityStoresCleanUp()
        {
            if (await _activityStores.Activities.AnyAsync())
            {
                var date = DateTime.Now.AddHours(-12);
                var 
                foreach (var item in )
                {
                    item.Values.RemoveAll(x => x.InsertedTimeStamp < date);
                }
            }
        }
    }
}
