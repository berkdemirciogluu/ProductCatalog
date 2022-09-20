using ProductCatalog.BackgroundWorkers.Entities;
using ProductCatalog.BackgroundWorkers.Services.Mail.RabbitMQ.Abstract;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCatalog.BackgroundWorkers.Services.Mail.RabbitMQ.Concrete
{
    public class ProducerService : IProducerService
    {
        private readonly IRabbitMqService _rabbitMqService;

        public ProducerService(IRabbitMqService rabbitMqService)
        {
            _rabbitMqService = rabbitMqService;
        }

        public void Publish(EmailToSend email, string queueName)
        {
            using var connection = _rabbitMqService.GetRabbitMqConnection();
            using var channel = connection.CreateModel();

            channel.QueueDeclare(queueName, false, false, false, null);
            var body = Encoding.UTF8.GetBytes(System.Text.Json.JsonSerializer.Serialize(email));

            channel.BasicPublish("", queueName, null, body: body);
        }
    }
}
