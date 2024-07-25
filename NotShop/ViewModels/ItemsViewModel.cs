using NotShop.Models;

namespace shop_net.ViewModels;

public class ItemsViewModel
{
    private IEnumerable<ImagedItem> items;
    public IEnumerable<ImagedItem> Items => items;

    public ItemsViewModel(IEnumerable<Item> items, IEnumerable<Image> images)
    {
        var imagedItems = new List<ImagedItem>();
        foreach (var item in items)
        {
            var itemImages = images.Where(x => x.Item.Id == item.Id);
            imagedItems.Add(new ImagedItem(item, itemImages));
        }
        this.items = imagedItems;
    }
}

public class ImagedItem : Item
{
    private IEnumerable<Image> images { get; set; }
    public IEnumerable<Image> Images => images;
    public ImagedItem(Item item, IEnumerable<Image> images)
    {
        Id = item.Id;
        Name = item.Name;
        Description = item.Description;
        Group = item.Group;
        Category = item.Category;
        SubCategory = item.SubCategory;
        Price = item.Price;

        this.images = images;
    }
}