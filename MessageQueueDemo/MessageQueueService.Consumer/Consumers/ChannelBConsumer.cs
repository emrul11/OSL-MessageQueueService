using MessageQueueService.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MessageQueueService.Consumer.Consumers
{
    public class ChannelBConsumer : MessageConsumerBase, IMessageConsumer
    {
        public ChannelBConsumer(string queueName) : base("ChannelBQueue")
        {
        }

        public override void ConsumeMessage()
        {
            throw new NotImplementedException();
        }
    }
}