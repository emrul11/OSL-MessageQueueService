using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MessageQueueService.Infrastructure.Queues
{
    public class ChannelBQueue
    {
        private readonly string _queueName = "ChannelBQueue";

        public void InitializeQueue(IConnection connection)
        {
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(_queueName, durable: true, exclusive: false, autoDelete: false, arguments: null);
                // Add any additional configuration you need for Channel B Queue
            }
        }
    }
}