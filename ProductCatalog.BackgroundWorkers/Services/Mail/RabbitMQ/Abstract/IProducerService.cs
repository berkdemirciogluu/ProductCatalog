using ProductCatalog.BackgroundWorkers.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCatalog.BackgroundWorkers.Services.Mail.RabbitMQ.Abstract
{
    public interface IProducerService
    {
        void Publish(EmailToSend email, string queueName);
    }
}
