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
        private readonly PublisherAService _publisherAService;
        private readonly PublisherBService _publisherBService;
        public MessageQueueServiceController()
        {
            _publisherAService = new PublisherAService();
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult PublishMessageChannelA()
        {
            return View();
        }

        [HttpPost]
        public ActionResult PublishMessageChannelA(string content)
        {
            try
            {
                var message = new MessageModel { Content = content };
                _publisherAService.PublishToChannels(message);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                // Log or handle the exception as needed
                return View("Error");
            }
        }
        [HttpGet]
        public ActionResult PublishMessageChannelB()
        {
            return View();
        }

        [HttpPost]
        public ActionResult PublishMessageChannelB(string content)
        {
            try
            {
                var message = new MessageModel { Content = content };
                _publisherBService.PublishToChannels(message);
                return RedirectToAction("PublishMessage");
            }
            catch (Exception ex)
            {
                // Log or handle the exception as needed
                return View("Error");
            }
        }
    }
}