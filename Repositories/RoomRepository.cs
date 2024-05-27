using System.Collections.Generic;
using System.Threading.Tasks;
using Hotel.Server.Data;
using Hotel.Server.Models;
using Hotel.Server.Repository.Contracts;
using Microsoft.EntityFrameworkCore;

namespace Hotel.Server.Repositories;

public class RoomRepository : BaseRepository<Room>, IRoomRepository
{
    public RoomRepository(DataContext context) : base(context)
    {
    }

    public void CreateRoom(Room Room)
    {
        Create(Room);
    }

    public void DeleteRoom(Room Room)
    {
        Delete(Room);
    }

    public void UpdateRoom(Room Room)
    {
        Update(Room);
    }

    public async Task<IEnumerable<Room>> GetAllCategories()
    {
        return await FindAll().ToListAsync();
    }

    public async Task<Room> GetRoomById(int id)
    {
        return await FindByCondition(r => r.ID == id).FirstOrDefaultAsync();
    }
}