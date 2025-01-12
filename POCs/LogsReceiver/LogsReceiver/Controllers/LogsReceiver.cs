using LogsReceiver.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace LogsReceiver.Controllers
{
    [ApiController]
    [Route("api/logs")]
    public class LogsReceiver : ControllerBase
    {
        private readonly LogsDbContext _dbContext;

        public LogsReceiver(LogsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpPost]
        public async Task<IActionResult> ReceiveLog([FromBody] List<SerilogEvent> logEvents)
        {
            foreach (var logEvent in logEvents)
            {
                var logEntry = new LogEntry
                {
                    Message = logEvent.MessageTemplate,
                    Level = logEvent.Level,
                    Timestamp = logEvent.Timestamp.ToString("o")
                };

                await _dbContext.LogEntries.AddAsync(logEntry);
            }

            await _dbContext.SaveChangesAsync();

            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetLogs()
        {
            var logs = await _dbContext.LogEntries.ToListAsync();
            return Ok(logs);
        }
    }

    public class SerilogEvent
    {
        [JsonProperty("Timestamp")]
        public DateTime Timestamp { get; set; }

        [JsonProperty("Level")]
        public string Level { get; set; }

        [JsonProperty("MessageTemplate")]
        public string MessageTemplate { get; set; }

        [JsonProperty("RenderedMessage")]
        public string RenderedMessage { get; set; } = string.Empty;

        [JsonProperty("Properties")]
        public Dictionary<string, object> Properties { get; set; } = new Dictionary<string, object>();

        [JsonProperty("Exception")]
        public string? Exception { get; set; } 
    }
}
