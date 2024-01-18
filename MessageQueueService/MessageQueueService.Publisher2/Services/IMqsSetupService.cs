using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MessageQueueService.Publisher2.Services
{
    public interface IMqsSetupService
    {
        void RegisterRabbitMq();
    }
}