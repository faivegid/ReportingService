using Microsoft.Extensions.Logging;
using ReportingService.CleaningHouse.CleaningService.Contract;
using ReportingService.Data.Repository.Contracct;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportingService.CleaningHouse.CleaningService.IMplementaiton
{
    public class TwelveHourCleaning : ITwelveHourCleaning
    {
        private readonly IActivityRepository _activityRepository;
        private readonly ILogger<TwelveHourCleaning> _logger;

        public TwelveHourCleaning(ILogger<TwelveHourCleaning> logger,IActivityRepository activityRepository)
        {
            _logger = logger;
            _activityRepository = activityRepository;
        }

        public async Task PerFormCleanUp()
        {
            _logger.LogInformation($"Starting 12 Clean Up Time:{DateTime.Now}");
            await _activityRepository.RunactivityStoresCleanUp();
        }
    }
}
