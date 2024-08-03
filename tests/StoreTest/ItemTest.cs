using shop_net.Interfaces;

namespace StoreTest;

public class TestingItem : BaseItem
{
    private BaseItem? parent;
    public TestingItem(BaseItem? parent, string url)
    {
        this.parent = parent;
        Url = url;
    }

    public override IItem? Parent
    {
        get => parent;
    }
}

public class Test
{
    [Fact]
    public void UrlTest()
    {
        var item = new TestingItem(null, "item");
        var sonItem = new TestingItem(item, "son");
        var grandsonItem = new TestingItem(sonItem, "grandson");
        
        Assert.Equal(item.FullUrl(), "/item");
        Assert.Equal(sonItem.FullUrl(), "/item/son");
        Assert.Equal(grandsonItem.FullUrl(), "/item/son/grandson");
    }
}