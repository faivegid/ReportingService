using ReportingService.Modela.Domain;
using ReportingService.Modela.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReportingService.Data
{
    public class ActivityStores
    {
        private static List<Activity> _activityStores;
        public static IList<Activity> ActivityContext => _activityStores ??= new List<Activity>();

        public static async Task AddActivityAsync(ActivityDTO activityDTO)
        {
            await Task.Run(() =>
            {
                var activity = ActivityContext.FirstOrDefault(a => a.Id == activityDTO.Id);

                if (activity == null)
                    activity = new Activity(activityDTO.Id, activityDTO.Value);
                else
                    activity.AddValue(activityDTO.Value);
            });
        }

        public static async Task<int> GetTwekveHourTaskValueSum(string id)
        {
            return await Task<int>.Run(() =>
            {
                var activity = ActivityContext.FirstOrDefault(a => a.Id == id);
                var date = DateTime.Now.AddHours(-12);

                if (activity == null)
                    return 0;
                else
                    return activity.Values.Where(x => x.InsertedTimeStamp >= date).Sum(x => x.Value);
            });
        }
    }
}
