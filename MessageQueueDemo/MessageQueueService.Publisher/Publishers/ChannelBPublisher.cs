using MessageQueueService.Common;
using MessageQueueService.Infrastructure.Connections;
using Newtonsoft.Json;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace MessageQueueService.Publisher.Publishers
{
    public class ChannelBPublisher
    {
        private readonly RabbitMQConnection _rabbitMQConnection;
        private readonly string _queueName = "ChannelBQueue";

        public ChannelBPublisher()
        {
            _rabbitMQConnection = new RabbitMQConnection();
        }

        public void PublishMessage(MessageModel message)
        {
            try
            {
                var connection = _rabbitMQConnection.CreateConnection();
                using (var channel = connection.CreateModel())
                {
                    channel.QueueDeclare(queue: _queueName,
                        durable: true,
                        exclusive: false,
                        autoDelete: false,
                        arguments: null);

                    var jsonString = JsonConvert.SerializeObject(message);
                    var body = Encoding.UTF8.GetBytes(jsonString);

                    var properties = channel.CreateBasicProperties();
                    properties.Persistent = true;

                    channel.BasicPublish(exchange: "",
                        routingKey: _queueName,
                        basicProperties: properties,
                        body: body);

                    Console.WriteLine($" [x] Sent '{message.Content}'" +
                        $" to {_queueName}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error publishing message to {_queueName}: {ex.Message}");
            }
        }
    }
}