using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace NotShop.Models;

[Serializable, BsonIgnoreExtraElements]
public class SubCategory
{
    [BsonId, BsonElement("_id"), BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }
    
    [BsonElement("name"), BsonRepresentation(BsonType.String)]
    public string Name { get; set; }
    
    [BsonElement ("category")]
    public Category Category { get; set; }
}