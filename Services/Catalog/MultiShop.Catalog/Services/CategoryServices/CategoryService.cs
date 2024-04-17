using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.DTOs.CategoryDTOs;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.CategoryServices;

public class CategoryService : ICategoryService
{
    private readonly IMongoCollection<Category> _categoryCollection;
    private readonly IMapper _mapper;

    public CategoryService(IMapper mapper,IDatabaseSettings _databaseSettings)
    {

        var client = new MongoClient(_databaseSettings.ConnectionString);
        var database = client.GetDatabase(_databaseSettings.DatabaseName);
        _categoryCollection = database.GetCollection<Category>(_databaseSettings.CategoryCollectionName);
        _mapper = mapper;
    }
    public Task CreateCategoryAsync(CreateCategoryDTO createCategoryDTO)
    {
       var values = _mapper.Map<Category>(createCategoryDTO);
       return Task.CompletedTask;
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
