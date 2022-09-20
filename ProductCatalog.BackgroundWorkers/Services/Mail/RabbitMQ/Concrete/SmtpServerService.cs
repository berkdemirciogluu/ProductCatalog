using Microsoft.Extensions.Configuration;
using ProductCatalog.BackgroundWorkers.Services.Mail.RabbitMQ.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace ProductCatalog.BackgroundWorkers.Services.Mail.RabbitMQ.Concrete
{
    public class SmtpServerService : ISmtpServerService
    {
        private readonly IConfiguration _configuration;
        public SmtpServerService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public SmtpClient GetSmtpClient()
        {
            var smtpClient = new SmtpClient(_configuration["Smtp:Host"])
            {
                Port = int.Parse(_configuration["Smtp:Port"]),
                Credentials = new NetworkCredential(_configuration["Smtp:Email"], _configuration["Smtp:Password"]),
                EnableSsl = true
            };

            return smtpClient;
        }

    }
}
