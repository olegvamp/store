using shop_net.Interfaces;

namespace NotShop.Models.Entities;

public class Subgroup : BaseItem
{
    public Group Group { get; set; }
    public IEnumerable<Category> Categories { get; set; }
    public override IItem? Parent
    {
        get => Group;
    }
}