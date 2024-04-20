using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.DTOs.ProductDetailDTOs;
using MultiShop.Catalog.Services.ProductDetailServices;

namespace MultiShop.Catalog.Controllers;
[Route("api/[controller]")]
[ApiController]
public class ProductDetailController : ControllerBase
{
    private readonly IProductDetailService _productDetailService;
    public ProductDetailController(IProductDetailService ProductDetailService)
    {
        _productDetailService = ProductDetailService;
    }
    [HttpGet]
    public async Task<IActionResult> ProductDetailList()
    {
        var values = await _productDetailService.GetAllProductDetailAsync();
        return Ok(values);
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetProductDetailById(string id)
    {
        var values = await _productDetailService.GetByIdProductDetailAsync(id);
        return Ok(values);
    }
    [HttpPost]
    public async Task<IActionResult> CreateProductDetail(CreateProductDetailDTO createDTO)
    {
        await _productDetailService.CreateProductDetailAsync(createDTO);
        return Ok("Ürün detayı başarıyla eklendi");
    }
    [HttpDelete]
    public async Task<IActionResult> DeleteProductDetail(string id)
    {
        await _productDetailService.DeleteProductDetailAsync(id);
        return Ok("Ürün detayı başarıyla silindi");
    }
    [HttpPut]
    public async Task<IActionResult> UpdateProductDetail(UpdateProductDetailDTO updateDTO)
    {
        await _productDetailService.UpdateProductDetailAsync(updateDTO);
        return Ok("Ürün detayı başarıyla güncellendi.");
    }
}
