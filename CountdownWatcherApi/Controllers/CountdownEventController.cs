using CountdownWatcherApi.Models.Entities;
using CountdownWatcherApi.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Serilog;
using System.Threading.Tasks;

namespace CountdownWatcherApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CountdownEventController: ControllerBase
    {
        private readonly ILogger<CountdownEventController> _logger;
        private readonly CountdownEventsService _countdownEventService;

        public CountdownEventController(ILogger<CountdownEventController> logger, CountdownEventsService countdownEventService)
        {
            _logger = logger;
            _countdownEventService = countdownEventService;
        }

        [HttpPut]
        public async Task<IActionResult> Create(CountdownEvent countdownEvent)
        {
            if (ModelState.IsValid)
            {
                var result = await _countdownEventService.Create(countdownEvent);
                if (!string.IsNullOrEmpty(result.Id))
                {
                    _logger.LogInformation("Event created: {Id}", result.Id);
                    return Created("", result);
                }
                
            }
            return BadRequest(ModelState);
        }
    }
}
