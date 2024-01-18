using System.Configuration;

namespace MessageQueueService.Common
{
    public class AppSettings
    {
        public static string RabbitMQUri => ConfigurationManager
            .AppSettings["RabbitMQUri"];
    }
}