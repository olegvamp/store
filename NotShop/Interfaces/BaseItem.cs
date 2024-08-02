namespace shop_net.Interfaces;

public abstract class BaseItem : IItem
{
    public Guid Id { get; set; }
    public string Url { get; set; }
    public string Name { get; set; }
    public IItem? Parent { get; set; }

    /// <summary>
    /// Получение полного URL-адреса
    /// </summary>
    /// <returns></returns>
    public string FullUrl()
    {
        var parent = Parent;
        var url = $"/{Url}";
        
        while (parent != null)
        {
            url = $"/{parent?.Url}{url}";
            parent = parent.Parent;
        }
        
        return url;
    }
}