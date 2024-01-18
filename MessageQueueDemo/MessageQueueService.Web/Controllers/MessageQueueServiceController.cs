using MessageQueueService.Common;
using MessageQueueService.Publisher.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MessageQueueService.Web.Controllers
{
    public class MessageQueueServiceController : Controller
    {
        private readonly PublisherService _publisherService;
        public MessageQueueServiceController()
        {
            _publisherService = new PublisherService();
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult PublishMessage()
        {
            return View();
        }

        [HttpPost]
        public ActionResult PublishMessage(string content)
        {
            try
            {
                var message = new MessageModel { Content = content };
                _publisherService.PublishToChannels(message);
                return RedirectToAction("PublishMessage");
            }
            catch (Exception ex)
            {
                return View("Error"); 
            }
        }
    }
}