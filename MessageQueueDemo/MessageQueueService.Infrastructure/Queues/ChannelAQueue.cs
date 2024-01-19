using RabbitMQ.Client;
using Serilog;

namespace MessageQueueService.Infrastructure.Queues
{
    public class ChannelAQueue
    {
        private readonly string _queueName = "ChannelAQueue";

        public void InitializeQueue(IModel connection)
        {
            try
            {
                connection.QueueDeclare(_queueName,
                    durable: true,
                    exclusive: false,
                    autoDelete: false,
                    arguments: null);            
            }
            catch (System.Exception ex)
            {
                Log.Information("Error initializing Channel A Queue", ex);
            }
}
    }
}