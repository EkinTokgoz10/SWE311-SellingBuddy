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
   class OrderPaymentSuccessIntegrationEventHandler:IIntegrationEventHandler<OrderPaymentSuccessIntegrationEvent>
     
     {
         private readonly ILogger< OrderPaymentSuccessIntegrationEventHandler > logger;

       private OrderPaymentSuccessIntegrationEventHandler(ILogger< OrderPaymentSuccessIntegrationEventHandler>logger)
       {

         this.logger = logger;

       }

        public Task Handler(OrderPaymentSuccessIntegrationEvent @event)
        {
          // send Fail Notifications (Sms, EMail, Push)

          logger.LogInformation($"Order Payment Success with OrderId : {@event.OrderId}");
          return Task.CompletedTask;


        }




    }


}