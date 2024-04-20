using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.DTOs.ProductDetailDTOs;
using MultiShop.Catalog.Services.ProductDetailServices;

namespace MultiShop.Catalog.Controllers;
[Route("api/[controller]")]
[ApiController]
public class ProductDetailController : ControllerBase
{
    private readonly IProductDetailService _ProductDetailService;
    public ProductDetailController(IProductDetailService ProductDetailService)
    {
        _ProductDetailService = ProductDetailService;
    }
    [HttpGet]
    public async Task<IActionResult> ProductDetailList()
    {
        var values = await _ProductDetailService.GetAllProductDetailAsync();
        return Ok(values);
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetProductDetailById(string id)
    {
        var values = await _ProductDetailService.GetByIdProductDetailAsync(id);
        return Ok(values);
    }
    [HttpPost]
    public async Task<IActionResult> CreateProductDetail(CreateProductDetailDTO createDTO)
    {
        await _ProductDetailService.CreateProductDetailAsync(createDTO);
        return Ok("Ürün detayı başarıyla eklendi");
    }
    [HttpDelete]
    public async Task<IActionResult> DeleteProductDetail(string id)
    {
        await _ProductDetailService.DeleteProductDetailAsync(id);
        return Ok("Ürün detayı başarıyla silindi");
    }
    [HttpPut]
    public async Task<IActionResult> UpdateProductDetail(UpdateProductDetailDTO updateDTO)
    {
        await _ProductDetailService.UpdateProductDetailAsync(updateDTO);
        return Ok("Ürün detayı başarıyla güncellendi.");
    }
}
