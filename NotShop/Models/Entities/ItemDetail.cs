namespace NotShop.Models.Entities;

public class ItemDetail 
{
    public Guid Id { get; set; }
    public Color Color { get; set; }
    public Size Size { get; set; }
    public int Count { get; set; }
    public double Price { get; set; }
    public double? DiscountedPrice { get; set; }
    public IEnumerable<string> Photos { get; set; }
}