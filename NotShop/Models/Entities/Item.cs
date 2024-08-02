using shop_net.Interfaces;

namespace NotShop.Models.Entities;

public class Item : BaseItem
{
    public Subcategory Subcategory { get; set; }
    public IEnumerable<ItemDetail> Details {get; set; }

}
