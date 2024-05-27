using Hotel.Server.Contracts.Service;
using Hotel.Server.Data.Dto.Category;
using Microsoft.AspNetCore.Mvc;

namespace Hotel.Server.Controllers;

[Route("api/categories")]
[ApiController]
public class CategoryController : ControllerBase
{
    private readonly IServiceManager _serviceManager;

    public CategoryController(IServiceManager serviceManager)
    {
        _serviceManager = serviceManager;
    }

    [HttpGet]
    public async Task<IActionResult> GetCategories()
    {
        var categories = await _serviceManager.CategoryService.GetAllCategories();

        return Ok(categories);
    }

    [HttpGet("{categoryId}")]
    public async Task<IActionResult> GetCategoryById(int categoryId)
    {
        var category = await _serviceManager.CategoryService.GetCategoryById(categoryId);

        return Ok(category);
    }

    [HttpPost]
    public async Task<IActionResult> CreateCategory(CategoryCreateDto createDto)
    {
        var response = await _serviceManager.CategoryService.CreateCategory(createDto);
        return Ok(response);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateCategory(CategoryUpdateDto updateDto)
    {
        var response = await _serviceManager.CategoryService.UpdateCategory(updateDto.CategoryID, updateDto);
        return Ok(response);
    }

    [HttpDelete("{categoryId}")]
    public async Task<IActionResult> DeleteCategory(int categoryId)
    {
        var response = await _serviceManager.CategoryService.DeleteCategory(categoryId);

        if (response)
            return Ok(response);

        return BadRequest();
    }
}