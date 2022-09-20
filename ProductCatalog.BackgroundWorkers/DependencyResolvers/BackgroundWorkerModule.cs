using Microsoft.Extensions.DependencyInjection;
using ProductCatalog.BackgroundWorkers.Services.Mail.RabbitMQ.Abstract;
using ProductCatalog.BackgroundWorkers.Services.Mail.RabbitMQ.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCatalog.BackgroundWorkers.DependencyResolvers
{
    public static class BackgroundWorkerModule 
    {
        public static void AddBackgroundWorkerServices(this IServiceCollection services)
        {
            services.AddScoped<ISmtpServerService, SmtpServerService>();
            services.AddSingleton<IProducerService, ProducerService>();
            services.AddSingleton<IRabbitMqService, RabbitMqService>();
        }
    }
}
