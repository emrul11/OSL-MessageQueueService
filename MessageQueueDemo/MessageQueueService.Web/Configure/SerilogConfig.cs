using Serilog;
using System;
using System.IO;

namespace MessageQueueService.Web.Configure
{
    public class SerilogConfig
    {
        public static void Configure()
        {
            string logFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Logs/log.txt");

            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.Console()
                .WriteTo.File(logFilePath, rollingInterval: RollingInterval.Day)
                .CreateLogger();
        }
    }
}