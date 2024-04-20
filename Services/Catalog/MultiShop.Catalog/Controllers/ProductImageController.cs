using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.DTOs.ProductImageDTOs;
using MultiShop.Catalog.Services.ProductImageServices;

namespace MultiShop.Catalog.Controllers;
[Route("api/[controller]")]
[ApiController]
public class ProductImageController : ControllerBase
{
    private readonly IProductImageService _ProductImageService;
    public ProductImageController(IProductImageService ProductImageService)
    {
        _ProductImageService = ProductImageService;
    }
    [HttpGet]
    public async Task<IActionResult> ProductImageList()
    {
        var values = await _ProductImageService.GetAllProductImageAsync();
        return Ok(values);
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetProductImageById(string id)
    {
        var values = _ProductImageService.GetByIdProductImageAsync(id);
        return Ok(values);
    }
    [HttpPost]
    public async Task<IActionResult> CreateProductImage(CreateProductImageDTO createDTO)
    {
        await _ProductImageService.CreateProductImageAsync(createDTO);
        return Ok("Ürün fotosu başarıyla eklendi");
    }
    [HttpDelete]
    public async Task<IActionResult> DeleteProductImage(string id)
    {
        await _ProductImageService.DeleteProductImageAsync(id);
        return Ok("Ürün fotosu başarıyla silindi");
    }
    [HttpPut]
    public async Task<IActionResult> UpdateProductImage(UpdateProductImageDTO updateDTO)
    {
        await _ProductImageService.UpdateProductImageAsync(updateDTO);
        return Ok("Ürün fotosu başarıyla güncellendi.");
    }
}
