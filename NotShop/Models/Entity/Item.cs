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
    
    [BsonElement("description"), BsonRepresentation(BsonType.String)]
    public string Description { get; set; }
    
    [BsonElement("group")]
    public Group Group { get; set; }
    
    [BsonElement("category")]
    public Category Category { get; set; }
    
    [BsonElement("subcategory")]
    public SubCategory SubCategory { get; set; }
    
    [BsonElement("price"), BsonRepresentation(BsonType.Double)]
    public double Price { get; set; }
}