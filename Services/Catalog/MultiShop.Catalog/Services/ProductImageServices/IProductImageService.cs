using MultiShop.Catalog.DTOs.ProductImageDTOs;

namespace MultiShop.Catalog.Services.ProductImageServices;

public interface IProductImageService
{
    Task<List<ResultProductImageDTO>> GetAllProductImageAsync();
    Task CreateProductImageAsync(CreateProductImageDTO createProductImageDto);
    Task UpdateProductImageAsync(UpdateProductImageDTO updateProductImageDto);
    Task DeleteProductImageAsync(string id);
    Task<GetByIdProductImageDTO> GetByIdProductImageAsync(string id);
}
