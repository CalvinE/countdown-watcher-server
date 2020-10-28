using CountdownWatcherApi.Models.Entities;
using CountdownWatcherApi.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Serilog;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.Net;

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

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Create))]
        public async Task<IActionResult> Create(CountdownEvent countdownEvent)
        {
            if (ModelState.IsValid)
            {
                var result = await _countdownEventService.Create(countdownEvent);
                if (!string.IsNullOrEmpty(result.Id))
                {
                    _logger.LogInformation("Event created: {Id}", result.Id);
                    return CreatedAtAction("Get", new { token = result.EventToken }, result);
                }
                
            }
            return BadRequest(ModelState.ToString());
        }

        [HttpGet("{token}")]
        [ResponseCache(Duration = 60, Location = ResponseCacheLocation.Any)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Get(string token)
        {
            if (string.IsNullOrEmpty(token))
            {
                return Problem("Event token is required", "", (int)HttpStatusCode.BadRequest, "", "");
            }

            var ce = await _countdownEventService.GetByEventToken(token);

            if (ce is null)
            {
                return NotFound();
            }

            return Ok(ce);
        }
    }
}
