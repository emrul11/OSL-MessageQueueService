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
        private readonly ChannelAPublisher2 _channelAPublisher2;
        private readonly ChannelBPublisher2 _channelBPublisher2;

        public PublisherService()
        {
            _channelAPublisher = new ChannelAPublisher();
            _channelBPublisher = new ChannelBPublisher();
            _channelAPublisher2 = new ChannelAPublisher2();
            _channelBPublisher2 = new ChannelBPublisher2();
        }
        public void PublishToChannelA(MessageModel message)
        {
            _channelAPublisher.PublishMessage(message);
        }

        public void PublishToChannelB(MessageModel message)
        {
            _channelBPublisher.PublishMessage(message);
        }
        public void PublishToChannelA2(MessageModel message)
        {
            _channelAPublisher.PublishMessage(message);
        }

        public void PublishToChannelB2(MessageModel message)
        {
            _channelBPublisher.PublishMessage(message);
        }
    }
}