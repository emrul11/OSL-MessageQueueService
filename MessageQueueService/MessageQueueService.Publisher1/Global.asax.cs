using Autofac;
using Autofac.Integration.Mvc;
using MessageQueueService.Publisher1.Services;
using Serilog;
using System;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace MessageQueueService.Publisher1
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {

            try
            {

                string logFilePath = Server.MapPath("~/Logs/log.txt");

                // Configure Serilog with console and file sinks
                Log.Logger = new LoggerConfiguration()
                    .WriteTo.File(logFilePath, rollingInterval: RollingInterval.Day)
                    .CreateLogger();
                AreaRegistration.RegisterAllAreas();
                FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
                RouteConfig.RegisterRoutes(RouteTable.Routes);
                BundleConfig.RegisterBundles(BundleTable.Bundles);

                //Autofac setup
                var builder = new ContainerBuilder();

                builder.RegisterType<MqsSetupService>().As<IMqsSetupService>();

                var container = builder.Build();
                DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

                var publisherService = container.Resolve<IMqsSetupService>();
                publisherService.RegisterRabbitMq();
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "An error occurred during application startup");
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }
    }
}
