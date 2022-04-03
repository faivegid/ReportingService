using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ReportingService.Data;
using ReportingService.Data.Repository.Contracct;
using ReportingService.Modela.DTOs;
using System.Threading.Tasks;

namespace ReportingService.API.Controllers
{
    [Route("activity")]
    [ApiController]
    public class ActivityConotroller : ControllerBase
    {
        private readonly ILogger<ActivityConotroller> _logger;
        private readonly IActivityRepository _activityRepository;
        public ActivityConotroller(ILogger<ActivityConotroller> logger,
            IActivityRepository activityRepository)
        {
            _logger = logger;
            _activityRepository = activityRepository;
        }

        [HttpPost("{key}")]
        public async Task<IActionResult> AddValueAsync(ActivityDTO dTO)
        {
            try
            {
                await _activityRepository.AddValueToActivityStoresAsync(dTO);
                return StatusCode(200);
            }
            catch (System.Exception ex)
            {
                _logger.LogError("An error Occured while proceeing your request", ex);
                return BadRequest("An error Occured while proceeing your request");
            }
        }

        [HttpGet("{key}")]
        public async Task<IActionResult> GetValues(string key)
        {
            try
            {
                int sum = await _activityRepository.GetSumOfActivityValues(key);
                return StatusCode(200, new { value = sum });
            }
            catch (System.Exception ex)
            {
                _logger.LogError("An error Occured while proceeing your request", ex);
                return BadRequest("An error Occured while proceeing your request");
            }
        }
    }
}
