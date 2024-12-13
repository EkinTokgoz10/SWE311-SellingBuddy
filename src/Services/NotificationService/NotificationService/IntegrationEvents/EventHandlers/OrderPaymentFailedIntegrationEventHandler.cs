using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EventBus.Base.Abstraction;
using PaymentService.Api.IntegrationEvents.Events;
using Microsoft.Extensions.Logging;

namespace NotificationService.IntegrationEvents.EventHandlers
{
   class OrderPaymentFailedIntegrationEventHandler:IIntegrationEventHandler<OrderPaymentFailedIntegrationEvent>
     
     {
         private readonly ILogger< OrderPaymentFailedIntegrationEventHandler > logger;

       private OrderPaymentFailedIntegrationEventHandler(ILogger< OrderPaymentFailedIntegrationEventHandler>logger)
       {

         this.logger = logger;

       }

        public Task Handler(OrderPaymentFailedIntegrationEvent @event)
        {
          // send Fail Notifications (Sms, EMail, Push)

          logger.LogInformation($"Order Payment failed with OrderId : {@event.OrderId}, ErrorMessage : {@event.ErrorMessage}");
          return Task.CompletedTask;


        }




    }


}