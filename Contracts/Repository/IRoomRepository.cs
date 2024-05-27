using System.Collections.Generic;
using System.Threading.Tasks;
using Hotel.Server.Models;

namespace Hotel.Server.Repository.Contracts;

public interface IRoomRepository : IBaseRepository<Room>
{
    Task<IEnumerable<Room>> GetAllCategories();
    Task<Room> GetRoomById(int id);
    void CreateRoom(Room Room);
    void DeleteRoom(Room Room);
    void UpdateRoom(Room Room);
}