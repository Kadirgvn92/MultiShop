using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.DTOs.CategoryDTOs;
using MultiShop.Catalog.Services.CategoryServices;

namespace MultiShop.Catalog.Controllers;
[Route("api/[controller]")]
[ApiController]
public class CategoriesController : ControllerBase
{
    private readonly ICategoryService _categoryService;

    public CategoriesController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }
    [HttpGet]
    public async Task<IActionResult> CategoryList()
    {
        var values = await _categoryService.GetAllCategoryAsync();
        return Ok(values);
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetCategoryById(string id)
    {
        var values = _categoryService.GetByIdCategoryAsync(id);
        return Ok(values);
    }
    [HttpPost]
    public async Task<IActionResult> CreateCategory(CreateCategoryDTO createDTO)
    {
        await _categoryService.CreateCategoryAsync(createDTO);
        return Ok("Kategori başarıyla eklendi");
    }
    [HttpDelete]
    public async Task<IActionResult> DeleteCategory(string id)
    {
        await _categoryService.DeleteCategoryAsync(id);
        return Ok("Kategori başarıyla silindi");
    }
    [HttpPut]
    public async Task<IActionResult> UpdateCategory(UpdateCategoryDTO updateDTO)
    {
        await _categoryService.UpdateCategoryAsync(updateDTO);
        return Ok("Kategori başarıyla güncellendi.");
    }
} 
