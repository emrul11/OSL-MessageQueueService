using RabbitMQ.Client;
using System;
using System.Text;

namespace MessageQueueService.Publisher1.Services
{
    public class MqsSetupService : IMqsSetupService
    {
        public void RegisterRabbitMq()
        {
            ConnectionFactory factory = new ConnectionFactory();
            factory.Uri = new Uri("amqp://guest:guest@localhost:5672");
            factory.ClientProvidedName = "Rabbit Sender App";

            IConnection connection = factory.CreateConnection();

            IModel channel = connection.CreateModel();

            string exchangeName = "DemoExchange";
            string routingKey = "demo-routing-key";
            string queuename = "DemoQueue";

            channel.ExchangeDeclare(exchangeName, ExchangeType.Direct);
            channel.QueueDeclare(queuename, false, false, false, null);
            channel.QueueBind(queuename, exchangeName, routingKey, null);

            byte[] messageBodyBytes = Encoding.UTF8.GetBytes("hello youtube");
            channel.BasicPublish(exchangeName, routingKey, null, messageBodyBytes);

            channel.Close();
            connection.Close();

        }

    }
}