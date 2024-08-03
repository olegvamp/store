using shop_net.Interfaces;

namespace NotShop.Models.Entities;

public class Group : BaseItem
{
    public IEnumerable<Subgroup> Subgroups { get; set; }
    public override IItem? Parent
    {
        get => null;
    }
}