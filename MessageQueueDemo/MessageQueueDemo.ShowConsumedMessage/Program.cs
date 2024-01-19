using MessageQueueDemo.ShowConsumedMessage.Services;
using Serilog;
using System;

namespace MessageQueueDemo.ShowConsumedMessage
{
    internal class Program
    {

        static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Debug()
            .WriteTo.Console()
            .WriteTo.File("Logs\\log.txt", rollingInterval: RollingInterval.Day)
            .CreateLogger();
            try
            {
                var consumerService = new MessageConsumerService();

                // Start consumers
                consumerService.StartConsumers();

                Log.Information("Application Starting");
                Console.WriteLine("Press [Enter] to exit.");
                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Applicaiton Failed to start");
            }

        }
    }
}
