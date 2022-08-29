using MassTransit;
using Producer.Consumer;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddMassTransit(x =>
{
    x.AddConsumer<OrderCreatedConsumerWeb>(typeof(OrderCreatedConsumerWebDefinition));
    x.AddConsumer<OrderCreatedConsumerWeb2>(typeof(OrderCreatedConsumerWebDefinition2));
       
    x.UsingRabbitMq((context, cfg) =>
    {
        cfg.ReceiveEndpoint("order-created-event", e =>
        {
            e.ConfigureConsumer<OrderCreatedConsumerWeb>(context);
          //  e.ConfigureConsumer<OrderCreatedConsumerWeb2>(context);
        });
    });
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();