public class Order
{
    public int OrderId { get; set; }
    public string ShipCountry { get; set; } = default!; // Add the 'required' modifier
    public decimal Freight { get; set; }
}