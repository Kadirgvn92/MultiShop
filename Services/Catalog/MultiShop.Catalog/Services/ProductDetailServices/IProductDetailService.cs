using MultiShop.Catalog.DTOs.ProductDetailDTOs;

namespace MultiShop.Catalog.Services.ProductDetailDetailServices;

public interface IProductDetailService
{
    Task<List<ResultProductDetailDTO>> GetAllProductDetailAsync();
    Task CreateProductDetailAsync(CreateProductDetailDTO createProductDetailDto);
    Task UpdateProductDetailAsync(UpdateProductDetailDTO updateProductDetailDto);
    Task DeleteProductDetailAsync(string id);
    Task<GetByIdProductDetailDTO> GetByIdProductDetailAsync(string id);
}
