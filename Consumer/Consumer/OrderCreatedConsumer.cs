using MassTransit;
using Shared;

namespace Consumer.Consumer;

public class OrderCreatedConsumer : IConsumer<OrderCreated>
{
    public async Task Consume(ConsumeContext<OrderCreated> context)
    {
        //var jsonMessage = JsonConvert.SerializeObject(context.Message);
        Console.WriteLine($"OrderCreated message: id:{context.Message.Id} name:{context.Message.ProductName}");
        await Task.Delay(context.Message.ProductName.Length*1000);

        
    }
}
