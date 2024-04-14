using MongoDB.Bson.Serialization.Attributes;

namespace MultiShop.Catalog.Entities;

public class ProductImages
{
    public string ProductImagesId { get; set; }
    public string Image1 { get; set; }
    public string Image2 { get; set; }
    public string Image3 { get; set; }
    public string ProductId { get; set; }
    public Product Product { get; set; }
}
