using shop_net.Interfaces;

namespace NotShop.Models.Entities;

public class Subcategory : BaseItem
{
    public Category Category { get; set; }
    public IEnumerable<Item> Items { get; set; }
}