using System.Collections.Generic;
using System.Threading.Tasks;
using Hotel.Server.Models;

namespace Hotel.Server.Contracts;

public interface IProductRepository : IRepositoryBase<Room>
{
    Task<IEnumerable<Room>> GetAllProducts();
    Task<Room> GetProductByID(int id);
    void CreateProduct(Room product);
    void DeleteProduct(Room product);
    void UpdateProduct(Room product);
}