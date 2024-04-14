using MongoDB.Bson.Serialization.Attributes;

namespace MultiShop.Catalog.Entities;

public class Category
{
    [BsonId]
    [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
    public string CategoryID { get; set; }
    public string Name { get; set; }
}
