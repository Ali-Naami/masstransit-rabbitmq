using MassTransit;
using Shared;

namespace Producer.Consumer;

public class OrderCreatedConsumerWeb : IConsumer<OrderCreated>
{
    public async Task Consume(ConsumeContext<OrderCreated> context)
    {
        //var jsonMessage = JsonConvert.SerializeObject(context.Message);
        Console.WriteLine($"web OrderCreated message: id:{context.Message.Id} name:{context.Message.ProductName}");
        await Task.Delay(context.Message.ProductName.Length*1000);
    }
    
    
}

class OrderCreatedConsumerWebDefinition :
        ConsumerDefinition<OrderCreatedConsumerWeb>
    {
        public OrderCreatedConsumerWebDefinition()
        {
            // override the default endpoint name
            EndpointName = "order-created-consumer-web-dis";

            // limit the number of messages consumed concurrently
            // this applies to the consumer only, not the endpoint
            ConcurrentMessageLimit = 8;
        }

        protected override void ConfigureConsumer(IReceiveEndpointConfigurator endpointConfigurator,
            IConsumerConfigurator<OrderCreatedConsumerWeb> consumerConfigurator)
        {
            // configure message retry with millisecond intervals
            endpointConfigurator.UseMessageRetry(r => r.Intervals(100,200,500,800,1000));

            // use the outbox to prevent duplicate events from being published
            endpointConfigurator.UseInMemoryOutbox();
        }
    }
