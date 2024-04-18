using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.DTOs.ProductDTOs;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.ProductServices;

public class ProductService : IProductService
{
    private readonly IMongoCollection<Product> _productCollection;
    private readonly IMapper _mapper;

    public ProductService(IMapper mapper, IDatabaseSettings _databaseSettings)
    {
        var client = new MongoClient(_databaseSettings.ConnectionString);
        var database = client.GetDatabase(_databaseSettings.DatabaseName);
        _productCollection = database.GetCollection<Product>(_databaseSettings.ProductCollectionName);
        _mapper = mapper;
    }
    public async Task CreateProductAsync(CreateProductDTO createProductDTO)
    {
        var values = _mapper.Map<Product>(createProductDTO);
        await _productCollection.InsertOneAsync(values);
    }

    public async Task DeleteProductAsync(string id)
    {
        await _productCollection.DeleteOneAsync(x => x.ProductID == id);
    }

    public async Task<List<ResultProductDTO>> GetAllProductAsync()
    {
        var values = await _productCollection.Find(x => true).ToListAsync();
        return _mapper.Map<List<ResultProductDTO>>(values);
    }

    public async Task<GetByIdProductDTO> GetByIdProductAsync(string id)
    {
        var values = await _productCollection.Find<Product>(x => x.ProductID == id).FirstOrDefaultAsync();
        return _mapper.Map<GetByIdProductDTO>(values);
    }

    public async Task UpdateProductAsync(UpdateProductDTO updateProductDTO)
    {
        var values = _mapper.Map<Product>(updateProductDTO);
        await _productCollection.FindOneAndReplaceAsync(x => x.ProductID == updateProductDTO.ProductID, values);

    }
}
