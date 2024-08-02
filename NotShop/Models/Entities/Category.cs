using shop_net.Interfaces;

namespace NotShop.Models.Entities;

public class Category : BaseItem
{
    public IEnumerable<Subcategory> Subcategories { get; set; }
}