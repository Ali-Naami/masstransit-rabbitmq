using MassTransit;
using Shared;

namespace Consumer.Consumer;

public class OrderCreatedConsumerNotify : IConsumer<OrderCreated2>
{
    public async Task Consume(ConsumeContext<OrderCreated2> context)
    {
        //var jsonMessage = JsonConvert.SerializeObject(context.Message);
        Console.WriteLine($"notify OrderCreated message: id:{context.Message.Id} name:{context.Message.ProductName}");
    }
}
