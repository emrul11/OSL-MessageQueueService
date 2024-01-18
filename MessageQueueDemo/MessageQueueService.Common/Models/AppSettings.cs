using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace MessageQueueService.Common
{
    public class AppSettings
    {
        public static string RabbitMQUri => ConfigurationManager
            .AppSettings["RabbitMQUri"];
    }
}