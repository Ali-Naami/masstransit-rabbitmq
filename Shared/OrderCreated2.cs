namespace Shared;

public interface OrderCreated2
{
    int Id { get; set; }
    string ProductName { get; set; }
    decimal Price { get; set; }
    int Quantity { get; set; }
}