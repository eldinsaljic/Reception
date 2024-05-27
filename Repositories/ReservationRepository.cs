using System.Collections.Generic;
using System.Threading.Tasks;
using Hotel.Server.Data;
using Hotel.Server.Models;
using Hotel.Server.Repository.Contracts;
using Microsoft.EntityFrameworkCore;

namespace Hotel.Server.Repositories;

public class ReservationRepository : BaseRepository<Reservation>, IReservationRepository
{
    public ReservationRepository(DataContext context) : base(context)
    {
    }

    public void CreateReservation(Reservation Reservation)
    {
        Create(Reservation);
    }

    public void DeleteReservation(Reservation Reservation)
    {
        Delete(Reservation);
    }

    public void UpdateReservation(Reservation Reservation)
    {
        Update(Reservation);
    }

    public async Task<IEnumerable<Reservation>> GetAllCategories()
    {
        return await FindAll().ToListAsync();
    }

    public async Task<Reservation> GetReservationById(int id)
    {
        return await FindByCondition(r => r.ID == id).FirstOrDefaultAsync();
    }
}