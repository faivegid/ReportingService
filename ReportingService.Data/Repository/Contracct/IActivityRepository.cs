using ReportingService.Modela.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportingService.Data.Repository.Contracct
{
    public interface IActivityRepository
    {
        /// <summary>
        /// Addd Activity if it doesnt exist with id and value 
        /// or add the value to the Activity if it exist
        /// </summary>
        /// <param name="activityDTO"></param>
        /// <returns></returns>
        Task AddValueToActivityStoresAsync(ActivityDTO dTO);

        /// <summary>
        /// Returns a sum of values inserted to the activity within the las 12 hours
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<int> GetSumOfActivityValues(string key);
        Task RunactivityStoresCleanUp();
    }
}
