using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MessageQueueService.Publisher1.Services
{
    public interface IMqsSetupService
    {
        void RegisterRabbitMq();
    }
}