﻿using MongoDB.Bson.Serialization.Attributes;

namespace MultiShop.Catalog.Entities;

public class Product
{
    [BsonId]  //BsonId attribute entitiylerde ıd belirlemek için kullanılır mongodbde
    [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)] //bu attribute mongoda objectıd eşsiz olmasını sağlar
    public string ProductID { get; set; }
    public string ProductName { get; set; }
    public decimal ProductPrice { get; set; }
    public string ProductImageUrl { get; set; }
    public string ProductDescription { get; set; }
    public string CategoryId { get; set; }
    [BsonIgnore] //BsonIgnore ise category nesnesini görmezden gelmesini sağlar bu sayede Category nesnesi db de boşuna yer kaplamaz
    public Category Category { get; set; }
}
