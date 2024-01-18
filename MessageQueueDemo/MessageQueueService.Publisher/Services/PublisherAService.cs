using MessageQueueService.Common;
using MessageQueueService.Publisher.Publishers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MessageQueueService.Publisher.Services
{
    public class PublisherAService
    {
        private readonly ChannelAPublisher _channelAPublisher;        

        public PublisherAService()
        {
            _channelAPublisher = new ChannelAPublisher();            
        }

        public void PublishToChannels(MessageModel message)
        {
            _channelAPublisher.PublishMessage(message);            
        }
    }
}