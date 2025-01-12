using Serilog.Core;
using Serilog.Events;

namespace LoggingPOC.LoggingConfigurations
{
    public class LogLevelHandler : ILogEventSink
    {

        public void Emit(LogEvent logEvent)
        {
            if (logEvent.Level == LogEventLevel.Error)
            {
                SendErrorAlert(logEvent);
            }
        }

        private void SendErrorAlert(LogEvent logEvent)
        {
            Console.WriteLine($"ERROR!!: {logEvent.MessageTemplate.ToString()}");
        }
    }
}
