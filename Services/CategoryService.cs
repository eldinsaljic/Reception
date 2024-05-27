using System.Collections.Generic;
using System.Threading.Tasks;
using Hotel.Server.Contracts.Service;
using Hotel.Server.Data.Dto;
using Hotel.Server.Data.Dto.Category;
using Hotel.Server.Models;
using Hotel.Server.Repository.Contracts;
using Mapster;

namespace Hotel.Server.Services;

public class CategoryService : ICategoryService
{
    private readonly IRepositoryManager _repositoryManager;
    private readonly ResponseDto _response;

    public CategoryService(IRepositoryManager repositoryManager)
    {
        _repositoryManager = repositoryManager;
        _response = new ResponseDto();
    }

    public async Task<ResponseDto> CreateCategory(CategoryCreateDto categoryDto)
    {
        var category = categoryDto.Adapt<Category>();
        _repositoryManager.CategoryRepository.CreateCategory(category);
        var result = await _repositoryManager.UnitOfWork.SaveChangesAsync();
        if (result > 0) return _response;
        _response.Success = false;
        _response.DisplayMessage = "Error Creating Category";
        return _response;
    }

    public async Task<ResponseDto> UpdateCategory(int categoryId, CategoryUpdateDto categoryDto)
    {
        var categoryCheck = await _repositoryManager.CategoryRepository.GetCategoryById(categoryId);
        if (categoryCheck is null)
        {
            _response.Success = false;
            _response.DisplayMessage = "Category not found in Database";
            return _response;
        }

        var category = categoryDto.Adapt<Category>();
        _repositoryManager.CategoryRepository.Update(category);

        var result = await _repositoryManager.UnitOfWork.SaveChangesAsync();
        if (result > 0) return _response;
        _response.Success = false;
        _response.DisplayMessage = "Error Updating Category";
        return _response;
    }

    public async Task<bool> DeleteCategory(int categoryID)
    {
        var category = await _repositoryManager.CategoryRepository.GetCategoryById(categoryID);
        if (category is null) return false;
        _repositoryManager.CategoryRepository.DeleteCategory(category);
        return await _repositoryManager.UnitOfWork.SaveChangesAsync() == 1;
    }

    public async Task<IEnumerable<CategoryReadOnlyDto>> GetAllCategories()
    {
        var categories = await _repositoryManager.CategoryRepository.GetAllCategories();
        return categories.Adapt<IEnumerable<CategoryReadOnlyDto>>();
    }

    public async Task<CategoryReadOnlyDto> GetCategoryById(int id)
    {
        var category = await _repositoryManager.CategoryRepository.GetCategoryById(id);
        return category.Adapt<CategoryReadOnlyDto>();
    }
}