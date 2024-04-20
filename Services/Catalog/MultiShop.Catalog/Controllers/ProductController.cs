using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.DTOs.ProductDTOs;
using MultiShop.Catalog.Services.ProductServices;

namespace MultiShop.Catalog.Controllers;
[Route("api/[controller]")]
[ApiController]
public class ProductController : ControllerBase
{
    private readonly IProductService _ProductService;
    public ProductController(IProductService ProductService)
    {
        _ProductService = ProductService;
    }
    [HttpGet]
    public async Task<IActionResult> ProductList()
    {
        var values = await _ProductService.GetAllProductAsync();
        return Ok(values);
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetProductById(string id)
    {
        var values = await _ProductService.GetByIdProductAsync(id);
        return Ok(values);
    }
    [HttpPost]
    public async Task<IActionResult> CreateProduct(CreateProductDTO createDTO)
    {
        await _ProductService.CreateProductAsync(createDTO);
        return Ok("Ürün başarıyla eklendi");
    }
    [HttpDelete]
    public async Task<IActionResult> DeleteProduct(string id)
    {
        await _ProductService.DeleteProductAsync(id);
        return Ok("Ürün başarıyla silindi");
    }
    [HttpPut]
    public async Task<IActionResult> UpdateProduct(UpdateProductDTO updateDTO)
    {
        await _ProductService.UpdateProductAsync(updateDTO);
        return Ok("Ürün başarıyla güncellendi.");
    }
}
