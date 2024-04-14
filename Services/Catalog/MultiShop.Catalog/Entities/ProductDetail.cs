using MongoDB.Bson.Serialization.Attributes;

namespace MultiShop.Catalog.Entities;

public class ProductDetail
{
    [BsonId]  //BsonId attribute entitiylerde ıd belirlemek için kullanılır mongodbde
    [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)] //bu attribute mongoda objectıd eşsiz olmasını sağlar
    public string ProductDetailId { get; set; }
    public string ProductDescription { get; set; }
    public string ProductInfo { get; set; }
    public string ProductId { get; set; }
    [BsonIgnore]
    public Product Product { get; set; }
}
