using System;
using NotificationService.IntegrationEvents.EventHandlers;
using PaymentService.Api.IntegrationEvents.Events;

namespace NotificationService
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ServiceCollection services = new ServiceCollection();
            
            ConfigureServices(services);
            
            var sp = services.BuildServiceProvider();

            IEventBus eventBus = sp.GetRequiredService<IEventBus>();

            eventBus.Subscribe<OrderPaymentSuccessIntegrationEvent, OrderPaymentSuccessIntegrationEventHandler>();

            eventBus.Subscribe<OrderPaymentFailedIntegrationEvent, OrderPaymentFailedIntegrationEventHandler>();
            
            Console.WriteLine("Application is Running...");

            Console.ReadLine();
        }

        private static void ConfigureServices(ServiceCollection service)
        {
        services.AddLogging(Configure =>
        {
          Configure.AddConsole();

        });

            services.AddTransient<OrderPaymentSuccessIntegrationEventHandler>();
            services.AddTransient<OrderPaymentFailedIntegrationEventHandler>();
          

           services.AddSingleton<IEventBus>(sp =>
           {
               EventBusConfig config = new()
               {
                   ConnectionRetryCount = 5,
                   EventNameSuffix = "IntegrationEvent",
                   SubscriberClientAppName = "NotificationService",
                   EventBusType = EventBusType.RabbitMQ
                };
            
                return EventBusFactory.Create(config, sp);
            });


        }

    }
}
