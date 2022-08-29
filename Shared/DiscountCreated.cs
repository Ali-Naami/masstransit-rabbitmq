namespace Shared;

public interface DiscountCreated
{
    int Id { get; set; }
    string ProductName { get; set; }
    decimal Price { get; set; }
    int Quantity { get; set; }
}