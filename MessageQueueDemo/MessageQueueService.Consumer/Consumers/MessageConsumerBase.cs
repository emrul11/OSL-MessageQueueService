using MessageQueueService.Common;
using MessageQueueService.Infrastructure.Connections;
using RabbitMQ.Client;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MessageQueueService.Consumer.Consumers
{
    public abstract class MessageConsumerBase
    {
        protected readonly RabbitMQConnection _rabbitMQConnection;
        protected readonly IConnection _connection;
        protected readonly IModel _channel;
        protected readonly string _queueName;
        protected readonly ILogger _logger;

        protected MessageConsumerBase(string queueName)
        {
            _rabbitMQConnection = new RabbitMQConnection();
            _channel = _rabbitMQConnection.GetModel();
            _queueName = queueName;           

            _channel.QueueDeclare(queue: _queueName,
                        durable: true,
                        exclusive: false,
                        autoDelete: false,
                        arguments: null);
        }

        public abstract void ConsumeMessage();

        protected void HandleMessage(MessageModel message)
        {
            Console.WriteLine($"Received message: {message.Content}");
        }
    }
}