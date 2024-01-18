using MessageQueueService.Infrastructure.Connections;
using MessageQueueService.Infrastructure.Queues;
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
               
        public MessageQueueServiceInitializer(RabbitMQConnection rabbitMQConnection, ChannelAQueue channelAQueue, ChannelBQueue channelBQueue)
        {
            _rabbitMQConnection = rabbitMQConnection;
            _channelAQueue = channelAQueue;
            _channelBQueue = channelBQueue;
        }

        public void Initialize()
        {
            // Initialize RabbitMQ connection
            var connection = _rabbitMQConnection.CreateConnection();

            // Initialize Channel A Queue
            _channelAQueue.InitializeQueue(connection);

            // Initialize Channel B Queue
            _channelBQueue.InitializeQueue(connection);
        }
    }
}