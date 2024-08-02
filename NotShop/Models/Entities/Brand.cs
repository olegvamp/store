using shop_net.Interfaces;

namespace NotShop.Models.Entities;

public class Brand : BaseItem
{
    public string Logo { get; set; }
    public string Description { get; set; }
}