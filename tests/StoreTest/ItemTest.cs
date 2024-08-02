using shop_net.Interfaces;

namespace StoreTest;

public class TestingItem : BaseItem
{
    public TestingItem()
    {
        
    }
}

public class Test
{
    [Fact]
    public void UrlTest()
    {
        var item = new TestingItem() { Parent = null, Url = "item" };
        var sonItem = new TestingItem() { Parent = item, Url = "son" };
        var grandsonItem = new TestingItem() { Parent = sonItem, Url = "grandson" };
        
        Assert.Equal(item.FullUrl(), "/item");
        Assert.Equal(sonItem.FullUrl(), "/item/son");
        Assert.Equal(grandsonItem.FullUrl(), "/item/son/grandson");
    }
}