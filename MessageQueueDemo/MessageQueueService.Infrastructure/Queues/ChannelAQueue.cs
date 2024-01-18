using RabbitMQ.Client;
using Serilog;
using System;

namespace MessageQueueService.Infrastructure.Queues
{
    public class ChannelAQueue
    {
        private readonly string _queueName = "ChannelAQueue";

        public void InitializeQueue(IConnection connection)
        {
            try
            {
                using (var channel = connection.CreateModel())
                {
                    channel.QueueDeclare(_queueName, 
                        durable: true, 
                        exclusive: false, 
                        autoDelete: false, 
                        arguments: null);
                }
            }
            catch (Exception ex)
            {
                Log.Information("Error initializing Channel A Queue", ex);
            }
        }
    }
}