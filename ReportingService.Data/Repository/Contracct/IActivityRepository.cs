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
        Task AddValueToActivityStoresAsync(ActivityDTO dTO);
        Task<int> GetSumOfActivityValues(string key);
    }
}
