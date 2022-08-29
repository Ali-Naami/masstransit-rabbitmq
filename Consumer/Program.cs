// See https://aka.ms/new-console-template for more information

using Consumer.Consumer;
using MassTransit;

Console.WriteLine("Hello, World!");

var busControl = Bus.Factory.CreateUsingRabbitMq(cfg =>
{
    cfg.ReceiveEndpoint("order-created-event", e =>
    {
        e.PrefetchCount = 0;
        e.Consumer<OrderCreatedConsumer>();
       // e.Consumer<OrderCreatedConsumerNotify>();
    });
});

await busControl.StartAsync(new CancellationToken());
try
{
    Console.WriteLine("Press enter to exit");
    await Task.Run(() => Console.ReadLine());
}
finally
{
    await busControl.StopAsync();
}