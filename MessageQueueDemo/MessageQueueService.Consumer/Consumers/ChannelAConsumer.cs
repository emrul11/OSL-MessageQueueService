using MessageQueueService.Common;
using MessageQueueService.Infrastructure.Connections;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MessageQueueService.Consumer.Consumers
{
    public class ChannelAConsumer : MessageConsumerBase, IChannelAConsumer
    {
        public ChannelAConsumer(string queueName) : base("ChannelAQueue")
        {
        }

        public override void ConsumeMessage()
        {
            var consumer = new EventingBasicConsumer(_channel);
            consumer.Received += (model, ea) =>
            {
                var body = ea.Body;
                var messageFromQueue = System.Text.Encoding.UTF8.GetString(body.ToArray());

                // Deserialize the message to MessageModel
                var messageModel = Newtonsoft.Json.JsonConvert.DeserializeObject<MessageModel>(messageFromQueue);
                Log.Information($"Received message from Channel A: {messageModel.Content}");
                // Handle the consumed message
                HandleMessage(messageModel);

                //Acknowledge the message to RabbitMQ
                _channel.BasicAck(deliveryTag: ea.DeliveryTag, multiple: false);
            };

            _channel.BasicConsume(queue: _queueName, autoAck: true, consumer: consumer);

        }
    }
}