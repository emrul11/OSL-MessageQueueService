using RabbitMQ.Client;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;

namespace MessageQueueService.Infrastructure.Queues
{
    public class ChannelBQueue
    {
        private readonly string _queueName = "ChannelBQueue";

        public void InitializeQueue(IModel connection)
        {
            try
            {
                {
                    connection.QueueDeclare(_queueName,
                        durable: true,
                        exclusive: false,
                        autoDelete: false,
                        arguments: null);
                }
            }
            catch (Exception ex)
            {
                Log.Information("Error initializing Channel B Queue", ex);
            }
        }
    }
}