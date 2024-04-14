using MongoDB.Bson.Serialization.Attributes;

namespace MultiShop.Catalog.Entities;

public class ProductDetail
{
    public string ProductDetailId { get; set; }
    public string ProductDescription { get; set; }
    public string ProductInfo { get; set; }
}
