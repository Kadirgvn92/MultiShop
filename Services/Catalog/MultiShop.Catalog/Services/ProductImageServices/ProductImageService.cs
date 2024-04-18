using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.DTOs.ProductImageDTOs;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.ProductImageServices;

public class ProductImageService : IProductImageService
{
    private readonly IMongoCollection<ProductImages> _ProductImageCollection;
    private readonly IMapper _mapper;

    public ProductImageService(IMapper mapper,IDatabaseSettings _databaseSettings)
    {
        var client = new MongoClient(_databaseSettings.ConnectionString);
        var database = client.GetDatabase(_databaseSettings.DatabaseName);
        _ProductImageCollection = database.GetCollection<ProductImages>(_databaseSettings.ProductImageCollectionName);
        _mapper = mapper;
    }
    public async Task CreateProductImageAsync(CreateProductImageDTO createProductImageDTO)
    {
       var values = _mapper.Map<ProductImages>(createProductImageDTO);
       await _ProductImageCollection.InsertOneAsync(values);
    }

    public async Task DeleteProductImageAsync(string id)
    {
        await _ProductImageCollection.DeleteOneAsync(x => x.ProductImagesId == id);
    }

    public async Task<List<ResultProductImageDTO>> GetAllProductImageAsync()
    {
        var values = await _ProductImageCollection.Find(x => true).ToListAsync();
        return _mapper.Map<List<ResultProductImageDTO>>(values);
    }

    public async Task<GetByIdProductImageDTO> GetByIdProductImageAsync(string id)
    {
        var values = await _ProductImageCollection.Find<ProductImages>(x => x.ProductImagesId == id).FirstOrDefaultAsync();
        return _mapper.Map<GetByIdProductImageDTO>(values);
    }

    public async Task UpdateProductImageAsync(UpdateProductImageDTO updateProductImageDTO)
    {
        var values = _mapper.Map<ProductImages>(updateProductImageDTO);
        await _ProductImageCollection.FindOneAndReplaceAsync(x => x.ProductImagesId == updateProductImageDTO.ProductImagesId,values);

    }
}
