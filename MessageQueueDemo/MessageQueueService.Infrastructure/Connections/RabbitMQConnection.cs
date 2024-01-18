using MessageQueueService.Common;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MessageQueueService.Infrastructure.Connections
{
    public class RabbitMQConnection
    {
        string rabbitMQUri = AppSettings.RabbitMQUri;

        public IConnection CreateConnection()
        {
            try
            {
                var factory = new ConnectionFactory
                {
                    Uri = new Uri(rabbitMQUri),
                    ClientProvidedName = "MessageQueueServiceDemo"
                };

                var connection = factory.CreateConnection();
                return connection;
            }
            catch (Exception ex)
            {
                // Log the exception or handle it as appropriate
                throw new Exception("Error creating RabbitMQ connection", ex);
            }
        }
    }
}