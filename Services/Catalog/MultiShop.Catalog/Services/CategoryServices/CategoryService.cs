using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.DTOs.CategoryDTOs;
using MultiShop.Catalog.Entities;

namespace MultiShop.Catalog.Services.CategoryServices;

public class CategoryService : ICategoryService
{
    private readonly IMongoCollection<Category> _categoryCollection;
    private readonly IMapper _mapper;
    public Task CreateCategoryAsync(CreateCategoryDTO createCategoryDTO)
    {
        throw new NotImplementedException();
    }

    public Task DeleteCategoryAsync(string id)
    {
        throw new NotImplementedException();
    }

    public Task<List<ResultCategoryDTO>> GetAllCategoryAsync()
    {
        throw new NotImplementedException();
    }

    public Task<GetByIdCategoryDTO> GetByIdCategoryAsync(string id)
    {
        throw new NotImplementedException();
    }

    public Task UpdateCategoryAsync(UpdateCategoryDTO updateCategoryDTO)
    {
        throw new NotImplementedException();
    }
}
