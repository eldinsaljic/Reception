using System.Collections.Generic;
using System.Threading.Tasks;
using Hotel.Server.Data;
using Hotel.Server.Models;
using Hotel.Server.Repository.Contracts;
using Microsoft.EntityFrameworkCore;

namespace Hotel.Server.Repositories;

public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
{
    public CategoryRepository(DataContext context) : base(context)
    {
    }

    public void CreateCategory(Category category)
    {
        Create(category);
    }

    public void DeleteCategory(Category category)
    {
        Delete(category);
    }

    public void UpdateCategory(Category category)
    {
        Update(category);
    }

    public async Task<IEnumerable<Category>> GetAllCategories()
    {
        return await FindAll().ToListAsync();
    }

    public async Task<Category> GetCategoryById(int id)
    {
        return await FindByCondition(category => category.CategoryID == id).FirstOrDefaultAsync();
    }
}