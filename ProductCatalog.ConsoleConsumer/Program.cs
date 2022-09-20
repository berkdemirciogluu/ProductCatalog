using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ProductCatalog.BackgroundWorkers.Entities;
using ProductCatalog.BackgroundWorkers.Services.Mail.RabbitMQ.Abstract;
using ProductCatalog.BackgroundWorkers.Services.Mail.RabbitMQ.Concrete;

namespace ProductCatalog.ConsoleConsumer

{
    class Program
    {
        public static async Task Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            var consumer = host.Services.GetRequiredService<Consumer>();

            var queue = RabbitMqQueue.EmailSenderQueue.ToString();

            consumer.Start(queue);
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args).ConfigureServices((services) =>
            {
                services.AddScoped<IConfiguration>(_ => new ConfigurationBuilder().AddJsonFile($"C:/Users/Barış/source/repos/UnluCoProductCatalog/WebAPI/appsettings.json").Build());
                services.AddScoped<IProducerService, ProducerService>();
                services.AddScoped<IRabbitMqService, RabbitMqService>();
                services.AddScoped<ISmtpServerService, SmtpServerService>();
                services.AddTransient<Consumer>();
            });


    }
}
