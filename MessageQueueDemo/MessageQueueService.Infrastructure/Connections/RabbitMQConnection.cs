﻿using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MessageQueueService.Infrastructure.Connections
{
    public class RabbitMQConnection
    {
        private const string RabbitMQUri = "amqp://guest:guest@localhost:5672";

        public IConnection CreateConnection()
        {
            try
            {
                var factory = new ConnectionFactory
                {
                    Uri = new Uri(RabbitMQUri),
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