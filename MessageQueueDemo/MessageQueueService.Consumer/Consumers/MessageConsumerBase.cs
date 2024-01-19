using MessageQueueService.Common;
using MessageQueueService.Infrastructure.Connections;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MessageQueueService.Consumer.Consumers
{
    public abstract class MessageConsumerBase
    {
        protected readonly RabbitMQConnection _rabbitMQConnection;
        protected IConnection _connection;
        protected IModel _channel;
        protected string _queueName;

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