using System.ComponentModel.DataAnnotations.Schema;

namespace shop_net.Interfaces;

public abstract class BaseItem : IItem
{
    public Guid Id { get; set; }
    public string Url { get; set; }
    public string Name { get; set; }
    [NotMapped]
    public virtual IItem? Parent { get; }

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