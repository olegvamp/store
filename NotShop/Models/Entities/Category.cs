using shop_net.Interfaces;

namespace NotShop.Models.Entities;

public class Category : BaseItem
{
    public Subgroup Subgroup { get; set; }
    public IEnumerable<Subcategory> Subcategories { get; set; }

    public override IItem? Parent
    {
        get => Subgroup;
    }
}