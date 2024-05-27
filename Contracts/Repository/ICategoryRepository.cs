using System.Collections.Generic;
using System.Threading.Tasks;
using Hotel.Server.Models;

namespace Hotel.Server.Repository.Contracts;

public interface ICategoryRepository : IBaseRepository<Category>
{
    Task<IEnumerable<Category>> GetAllCategories();
    Task<Category> GetCategoryById(int id);
    void CreateCategory(Category category);
    void DeleteCategory(Category category);
    void UpdateCategory(Category category);
}