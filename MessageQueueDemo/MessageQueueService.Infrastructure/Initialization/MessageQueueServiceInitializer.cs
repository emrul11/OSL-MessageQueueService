using MessageQueueService.Infrastructure.Connections;
using MessageQueueService.Infrastructure.Queues;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MessageQueueService.Infrastructure.Initialization
{
    public class MessageQueueServiceInitializer
    {
        private readonly RabbitMQConnection _rabbitMQConnection;
        private readonly ChannelAQueue _channelAQueue;
        private readonly ChannelBQueue _channelBQueue;
               
        public MessageQueueServiceInitializer(RabbitMQConnection rabbitMQConnection, 
            ChannelAQueue channelAQueue, 
            ChannelBQueue channelBQueue)
        {
            _rabbitMQConnection = rabbitMQConnection;
            _channelAQueue = channelAQueue;
            _channelBQueue = channelBQueue;
        }

        public void Initialize()
        {
            try
            {
                var connection = _rabbitMQConnection.GetModel();

                _channelAQueue.InitializeQueue(connection);

                _channelBQueue.InitializeQueue(connection);
            }
            catch (Exception ex)
            {
                Log.Information("Error during MessageQueueService initialization", ex);
            }
        }
    }
}