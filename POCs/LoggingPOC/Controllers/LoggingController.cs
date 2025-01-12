using Microsoft.AspNetCore.Mvc;

namespace LoggingPOC.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoggingController : ControllerBase
    {
        private readonly ILogger<LoggingController> _logger;

        public LoggingController(ILogger<LoggingController> logger)
        {
            _logger = logger;
        }

        [HttpGet("{index}")]
        public IActionResult Get(int index)
        {
            _logger.LogInformation("This is the information log");
            _logger.LogTrace("This is a trace log that contains index value: {Index}", index); 

            try
            {
                if (index == 0)
                {
                    _logger.LogWarning("This is a warning log");
                    throw new Exception("MyException was thrown");
                }
                _logger.LogDebug("This is a log debug");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "This is an error log");
            }

            return Ok(index);
        }
    }
}
