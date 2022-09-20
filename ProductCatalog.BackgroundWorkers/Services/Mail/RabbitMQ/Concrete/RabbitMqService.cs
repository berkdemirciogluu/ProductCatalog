using ProductCatalog.BackgroundWorkers.Services.Mail.RabbitMQ.Abstract;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCatalog.BackgroundWorkers.Services.Mail.RabbitMQ.Concrete
{
    public class RabbitMqService : IRabbitMqService
    {

        public IConnection GetRabbitMqConnection()
        {
            ConnectionFactory connectionFactory = new()
            {
                HostName = "localhost"
            };

            return connectionFactory.CreateConnection();
        }
    }
}
