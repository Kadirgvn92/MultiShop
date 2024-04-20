using AutoMapper;
using MultiShop.Catalog.DTOs.CategoryDTOs;
using MultiShop.Catalog.DTOs.ProductDetailDTOs;
using MultiShop.Catalog.DTOs.ProductDTOs;
using MultiShop.Catalog.DTOs.ProductImageDTOs;
using MultiShop.Catalog.Entities;

namespace MultiShop.Catalog.Mapping;

public class GeneralMapping : Profile
{
    public GeneralMapping()
    {
        CreateMap<Category,ResultCategoryDTO>().ReverseMap();
        CreateMap<Category,CreateCategoryDTO>().ReverseMap();
        CreateMap<Category,UpdateCategoryDTO>().ReverseMap();
        CreateMap<Category,GetByIdCategoryDTO>().ReverseMap();

        CreateMap<Product,ResultProductDTO>().ReverseMap();
        CreateMap<Product,CreateProductDTO>().ReverseMap();
        CreateMap<Product,UpdateProductDTO>().ReverseMap();
        CreateMap<Product,GetByIdProductDTO>().ReverseMap();

        CreateMap<ProductDetail,ResultProductDetailDTO>().ReverseMap();
        CreateMap<ProductDetail,CreateProductDetailDTO>().ReverseMap();
        CreateMap<ProductDetail,UpdateProductDetailDTO>().ReverseMap();
        CreateMap<ProductDetail,GetByIdProductDetailDTO>().ReverseMap();


        CreateMap<ProductImages,GetByIdProductImageDTO>().ReverseMap();
        CreateMap<ProductImages,CreateProductImageDTO>().ReverseMap();
        CreateMap<ProductImages,UpdateProductImageDTO>().ReverseMap();
        CreateMap<ProductImages,ResultProductImageDTO>().ReverseMap();
    }
}
