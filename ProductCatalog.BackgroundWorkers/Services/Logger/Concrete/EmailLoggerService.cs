using ProductCatalog.BackgroundWorkers.Entities;
using ProductCatalog.BackgroundWorkers.Services.Logger.Abstract;
using ProductCatalog.BackgroundWorkers.Services.Mail.RabbitMQ.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCatalog.BackgroundWorkers.Services.Logger.Concrete
{
    public class EmailLoggerService : ILoggerService
    {
        private readonly IProducerService _publisherService;

        public EmailLoggerService(IProducerService publisherService)
        {
            _publisherService = publisherService;
        }
        public void Log(string message)
        {
            var email = new EmailToSend()
            {
                To = "........@gmail.com",
                Subject = "User Gestures",
                Body = message,
            };
            Console.WriteLine("Logged to Email");
            _publisherService.Publish(email, RabbitMqQueue.EmailSenderQueue.ToString());
        }
    }
}
