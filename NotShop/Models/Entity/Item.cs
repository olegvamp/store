using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace NotShop.Models;

[Serializable, BsonIgnoreExtraElements]
public class Item
{
    [BsonId, BsonElement("_id"), BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }
    
    [BsonElement("name"), BsonRepresentation(BsonType.String)]
    public string Name { get; set; }
    
    public string Description { get; set; }
    
    public Category Category { get; set; }
    
    public SubCategory SubCategory { get; set; }
    
    public double Price { get; set; }
    
}