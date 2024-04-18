using MultiShop.Catalog.DTOs.CategoryDTOs;

namespace MultiShop.Catalog.Services.CategoryServices;

public interface ICategoryService
{
    Task<List<ResultCategoryDTO>> GetAllCategoryAsync();
    Task CreateCategoryAsync(CreateCategoryDTO createCategoryDto);
    Task UpdateCategoryAsync(UpdateCategoryDTO updateCategoryDto);
    Task DeleteCategoryAsync(string id);
    Task<GetByIdCategoryDTO> GetByIdCategoryAsync(string id);
}
