using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace NotShop.Models;

[Serializable, BsonIgnoreExtraElements]
public class Image
{
    [BsonId, BsonElement("_id"), BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }
    
    [BsonElement("url"), BsonRepresentation(BsonType.String)]
    public string Url { get; set; }
    
    [BsonElement ("item")]
    public Item Item { get; set; }
    
    [BsonElement("is_main"), BsonRepresentation(BsonType.Boolean)]
    public bool IsMain { get; set; }
}