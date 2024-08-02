namespace shop_net.Interfaces;

public interface IItem
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public string Url { get; set; }
    public IItem? Parent { get; set; }
}