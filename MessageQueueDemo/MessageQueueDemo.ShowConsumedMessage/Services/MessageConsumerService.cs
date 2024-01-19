using MessageQueueService.Consumer.Consumers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageQueueDemo.ShowConsumedMessage.Services
{
    public class MessageConsumerService
    {
        private readonly ChannelAConsumer _channelAConsumer;
        private readonly ChannelBConsumer _channelBConsumer;

        public MessageConsumerService()
        {
            _channelAConsumer = new ChannelAConsumer();
            _channelBConsumer = new ChannelBConsumer();
        }
        public void StartConsumers()
        {
            _channelAConsumer.ConsumeMessage();
            _channelBConsumer.ConsumeMessage();
        }
    }
}
