using MessageQueueService.Common;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using Serilog;
using System;

namespace MessageQueueService.Consumer.Consumers
{
    public class ChannelBConsumer : MessageConsumerBase, IMessageConsumer
    {
        public ChannelBConsumer() : base("ChannelBQueue")
        {
        }

        public override void ConsumeMessage()
        {
            var consumer = new EventingBasicConsumer(_channel);
            consumer.Received += (model, ea) =>
            {
                var body = ea.Body;
                var messageFromQueue = System.Text.Encoding.UTF8.GetString(body.ToArray());

                if (messageFromQueue != null)
                {
                    var messageModel = Newtonsoft.Json.JsonConvert
                    .DeserializeObject<MessageModel>(messageFromQueue);
                    
                    HandleMessage(messageModel);

                    //Acknowledge the message to RabbitMQ
                   // _channel.BasicAck(deliveryTag: ea.DeliveryTag, multiple: false);
                }
            };

            _channel.BasicConsume(queue: _queueName, autoAck: true, consumer: consumer);

        }
    }
}