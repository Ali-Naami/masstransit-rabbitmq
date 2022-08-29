using MassTransit;
using Shared;

namespace Producer.Consumer;

public class OrderCreatedConsumerWeb2 : IConsumer<DiscountCreated>
{
    public async Task Consume(ConsumeContext<DiscountCreated> context)
    {
        //var jsonMessage = JsonConvert.SerializeObject(context.Message);
        Console.WriteLine($"web OrderCreated message: id:{context.Message.Id} name:{context.Message.ProductName}");
        
    }
    
    
}

class OrderCreatedConsumerWebDefinition2 :
        ConsumerDefinition<OrderCreatedConsumerWeb2>
    {
        public OrderCreatedConsumerWebDefinition2()
        {
            // override the default endpoint name
            EndpointName = "order-created-consumer-web-dis";

            // limit the number of messages consumed concurrently
            // this applies to the consumer only, not the endpoint
            ConcurrentMessageLimit = 8;
        }

        protected override void ConfigureConsumer(IReceiveEndpointConfigurator endpointConfigurator,
            IConsumerConfigurator<OrderCreatedConsumerWeb2> consumerConfigurator)
        {
            // configure message retry with millisecond intervals
            endpointConfigurator.UseMessageRetry(r => r.Intervals(100,200,500,800,1000));

            // use the outbox to prevent duplicate events from being published
            endpointConfigurator.UseInMemoryOutbox();
        }
    }
