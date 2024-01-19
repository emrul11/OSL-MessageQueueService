using MessageQueueService.Common;
using MessageQueueService.Infrastructure.Connections;
using Newtonsoft.Json;
using RabbitMQ.Client;
using System;
using System.Text;

namespace MessageQueueService.Publisher.Publishers
{
    public class ChannelBPublisher2 : BaseMessagePublisher
    {
        public ChannelBPublisher2() : base(new RabbitMQConnection(), "ChannelBQueue")
        {
        }

        public override void PublishMessage(MessageModel message)
        {
            try
            {
                var connection = _rabbitMQConnection.CreateConnection();
                using (var channel = connection.CreateModel())
                {
                    channel.QueueDeclare(queue: QueueName,
                        durable: true,
                        exclusive: false,
                        autoDelete: false,
                        arguments: null);

                    var jsonString = JsonConvert.SerializeObject(message);
                    var body = Encoding.UTF8.GetBytes(jsonString);

                    var properties = channel.CreateBasicProperties();
                    properties.Persistent = true;

                    channel.BasicPublish(exchange: "",
                        routingKey: QueueName,
                        basicProperties: properties,
                        body: body);

                    Console.WriteLine($" [x] Sent '{message.Content}'" +
                        $" to {QueueName}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error publishing message to {QueueName}: {ex.Message}");
            }
        }
    }
}
