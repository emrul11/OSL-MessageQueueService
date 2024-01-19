using MessageQueueService.Common;
using MessageQueueService.Infrastructure.Connections;
using RabbitMQ.Client;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace MessageQueueService.Publisher.Publishers
{
    public abstract class BaseMessagePublisher
    {
        protected readonly RabbitMQConnection _rabbitMQConnection;
        protected readonly string QueueName;

        protected BaseMessagePublisher(RabbitMQConnection rabbitMQConnection, string queueName)
        {
            _rabbitMQConnection = rabbitMQConnection ?? throw new ArgumentNullException(nameof(rabbitMQConnection));
            QueueName = queueName ?? throw new ArgumentNullException(nameof(queueName));
        }

        public abstract void PublishMessage(MessageModel message);
    }
}