using MongoDB.Bson.Serialization.Attributes;

namespace MultiShop.Catalog.Entities;

public class ProductImages
{
    [BsonId]  //BsonId attribute entitiylerde ıd belirlemek için kullanılır mongodbde
    [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)] //bu attribute mongoda objectıd eşsiz olmasını sağlar
    public string ProductImagesId { get; set; }
    public string Image1 { get; set; }
    public string Image2 { get; set; }
    public string Image3 { get; set; }
    public string ProductId { get; set; }
    [BsonIgnore]
    public Product Product { get; set; }
}
