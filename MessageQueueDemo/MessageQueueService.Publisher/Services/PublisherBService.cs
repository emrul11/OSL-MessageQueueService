using MessageQueueService.Common;
using MessageQueueService.Publisher.Publishers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MessageQueueService.Publisher.Services
{
    public class PublisherBService
    {
        private readonly ChannelBPublisher _channelAPublisher;

        public PublisherBService()
        {
            _channelAPublisher = new ChannelBPublisher();
        }

        public void PublishToChannels(MessageModel message)
        {
            _channelAPublisher.PublishMessage(message);
        }
    }
}