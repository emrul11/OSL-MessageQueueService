using RabbitMQ.Client;
using System;

namespace MessageQueueService.Infrastructure.Connections
{
    public class RabbitMQConnection
    {
        private const string rabbitMQUri = "amqp://guest:guest@localhost:5672";
        private IConnection _connection;
        public IConnection CreateConnection()
        {
            if (_connection != null)
            {
                return _connection;
            }
            try
            {
                var factory = new ConnectionFactory
                {
                    Uri = new Uri(rabbitMQUri),
                    ClientProvidedName = "MessageQueueServiceDemo"
                };

                _connection = factory.CreateConnection();
                return _connection;
            }
            catch (Exception ex)
            {
                // Log the exception or handle it as appropriate
                throw new Exception("Error creating RabbitMQ connection", ex);
            }
        }
        public IModel GetModel()
        {
            var con = CreateConnection();
            return con.CreateModel();
        }
    }
}