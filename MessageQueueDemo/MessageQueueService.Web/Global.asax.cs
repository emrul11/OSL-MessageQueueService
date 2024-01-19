using MessageQueueService.Consumer.Consumers;
using MessageQueueService.Consumer.Services;
using MessageQueueService.Infrastructure.Connections;
using MessageQueueService.Infrastructure.Initialization;
using MessageQueueService.Infrastructure.Queues;
using MessageQueueService.Web.Configure;
using Serilog;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace MessageQueueService.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            try
            {
                SerilogConfig.Configure();
                Log.Information("Application Starting");

                // Manually instantiate dependencies
                var rabbitMQConnection = new RabbitMQConnection();
                var channelAQueue = new ChannelAQueue();
                var channelBQueue = new ChannelBQueue();

                var messageQueueServiceInitializer =
                    new MessageQueueServiceInitializer(rabbitMQConnection,
                    channelAQueue,
                    channelBQueue);

                // Use the initialized service as needed
                messageQueueServiceInitializer.Initialize();

                var consumers = new List<IMessageConsumer>
                {
                    new ChannelAConsumer(Log.Logger),
                    new ChannelBConsumer(Log.Logger),
                    // Add other consumer instances as needed
                };

                var consumerService = new ConsumerService(consumers, Log.Logger);
                consumerService.StartConsumers();

                AreaRegistration.RegisterAllAreas();
                FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
                RouteConfig.RegisterRoutes(RouteTable.Routes);
                BundleConfig.RegisterBundles(BundleTable.Bundles);
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Applicaiton Failed to start");
            }
        }
    }
}
