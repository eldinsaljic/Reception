using System.Collections.Generic;
using System.Threading.Tasks;
using Hotel.Server.Data.Dto;
using Hotel.Server.Data.Dto.Category;

namespace Hotel.Server.Contracts.Service;

public interface ICategoryService
{
    Task<IEnumerable<CategoryReadOnlyDto>> GetAllCategories();
    Task<CategoryReadOnlyDto> GetCategoryById(int id);
    Task<ResponseDto> CreateCategory(CategoryCreateDto categoryDto);
    Task<ResponseDto> UpdateCategory(int categoryId, CategoryUpdateDto categoryDto);
    Task<bool> DeleteCategory(int categoryID);
}