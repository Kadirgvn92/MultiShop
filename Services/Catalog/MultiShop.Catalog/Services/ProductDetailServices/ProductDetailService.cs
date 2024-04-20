using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.DTOs.ProductDetailDTOs;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.ProductDetailServices;

public class ProductDetailService : IProductDetailService
{
    private readonly IMapper _mapper;
    private readonly IMongoCollection<ProductDetail> _ProductDetailCollection;

    public ProductDetailService(IMapper mapper, IDatabaseSettings _databaseSettings)
    {
        _mapper = mapper;
        var client = new MongoClient(_databaseSettings.ConnectionString);
        var database = client.GetDatabase(_databaseSettings.ConnectionString);
        _ProductDetailCollection = database.GetCollection<ProductDetail>(_databaseSettings.ProductDetailCollectionName);
    }

    public async Task CreateProductDetailAsync(CreateProductDetailDTO createProductDetailDto)
    {
        var values = _mapper.Map<ProductDetail>(createProductDetailDto);
        await _ProductDetailCollection.InsertOneAsync(values);
    }

    public async Task DeleteProductDetailAsync(string id)
    {
        await _ProductDetailCollection.DeleteOneAsync(x => x.ProductId == id);
    }

    public async Task<List<ResultProductDetailDTO>> GetAllProductDetailAsync()
    {
        var values = await _ProductDetailCollection.Find(x => true).ToListAsync();
        return _mapper.Map<List<ResultProductDetailDTO>>(values);
    }

    public async Task<GetByIdProductDetailDTO> GetByIdProductDetailAsync(string id)
    {
        var values = await _ProductDetailCollection.Find<ProductDetail>(x => x.ProductId == id).FirstOrDefaultAsync();
        return _mapper.Map<GetByIdProductDetailDTO>(values);
    }

    public async Task UpdateProductDetailAsync(UpdateProductDetailDTO updateProductDetailDto)
    {
        var values = _mapper.Map<ProductDetail>(updateProductDetailDto);
        await _ProductDetailCollection.FindOneAndReplaceAsync(x => x.ProductId == updateProductDetailDto.ProductId, values);
    }
}
