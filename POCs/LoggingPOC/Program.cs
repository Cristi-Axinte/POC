using LoggingPOC.LoggingConfigurations;
using Serilog;
using Serilog.Events;

namespace LoggingPOC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Verbose()
                .WriteTo.Console()
                .WriteTo.File("logs/log-.txt", rollingInterval: RollingInterval.Day)
                .WriteTo.Http("http://localhost:5049/api/logs",
                restrictedToMinimumLevel: LogEventLevel.Verbose,   //this can be removed in case we don`t want logDebug too
                textFormatter: new Serilog.Formatting.Json.JsonFormatter(),
                queueLimitBytes: null, period: TimeSpan.FromSeconds(10))
                .WriteTo.Sink(new LogLevelHandler())  //this handles what happens for specific types of logs
                .CreateLogger();

            Serilog.Debugging.SelfLog.Enable(msg => Console.WriteLine("Serilog debugging" + msg)); // this is used to debug serilog in case something does not work

            // Build the application
            var builder = WebApplication.CreateBuilder(args);

            builder.Host.UseSerilog();

            // Add services to the container.
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAll",
                    policy =>
                    {
                        policy.AllowAnyOrigin()
                              .AllowAnyHeader()
                              .AllowAnyMethod();
                    });
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            // Run the application
            app.Run();
        }
    }
}
