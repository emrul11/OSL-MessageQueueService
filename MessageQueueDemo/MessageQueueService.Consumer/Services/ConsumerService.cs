using MessageQueueService.Consumer.Consumers;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MessageQueueService.Consumer.Services
{
    public class ConsumerService
    {
        private readonly List<IMessageConsumer> _consumers;
        protected readonly ILogger _logger;

        public ConsumerService(List<IMessageConsumer> consumers, ILogger logger)
        {
            _consumers = consumers ?? throw new ArgumentNullException(nameof(consumers));
            _logger = logger;
        }

        public void StartConsumers()
        {
            foreach (var consumer in _consumers)
            {
                consumer.ConsumeMessage();
            }
        }
    }
}