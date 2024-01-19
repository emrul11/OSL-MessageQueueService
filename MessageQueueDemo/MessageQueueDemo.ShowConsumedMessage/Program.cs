using MessageQueueService.Consumer.Consumers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageQueueDemo.ShowConsumedMessage
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var channelAConsumer = new ChannelAConsumer();
            var channelBConsumer = new ChannelBConsumer();

            Console.WriteLine("Press [Enter] to exit.");
            Console.ReadLine();
        }
    }
}
