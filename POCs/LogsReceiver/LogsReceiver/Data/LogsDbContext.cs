using Microsoft.EntityFrameworkCore;

namespace LogsReceiver.Data
{
    public class LogsDbContext : DbContext
    {
        public LogsDbContext(DbContextOptions<LogsDbContext> options) : base(options) { }

        public DbSet<LogEntry> LogEntries { get; set; }
    }
}
