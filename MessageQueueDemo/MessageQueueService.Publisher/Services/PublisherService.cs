using MessageQueueService.Common;
using MessageQueueService.Publisher.Publishers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MessageQueueService.Publisher.Services
{
    public class PublisherService
    {
        private readonly ChannelAPublisher _channelAPublisher;
        private readonly ChannelBPublisher _channelBPublisher;

        public PublisherService()
        {
            _channelAPublisher = new ChannelAPublisher();
            _channelBPublisher = new ChannelBPublisher();
        }
        public void PublishToChannelA(MessageModel message)
        {
            _channelAPublisher.PublishMessage(message);
        }

        public void PublishToChannelB(MessageModel message)
        {
            _channelBPublisher.PublishMessage(message);
        }
    }
}