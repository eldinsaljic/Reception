using System.Collections.Generic;
using System.Threading.Tasks;
using Hotel.Server.Models;

namespace Hotel.Server.Repository.Contracts;

public interface IReservationRepository : IBaseRepository<Reservation>
{
    Task<IEnumerable<Reservation>> GetAllCategories();
    Task<Reservation> GetReservationById(int id);
    void CreateReservation(Reservation Reservation);
    void DeleteReservation(Reservation Reservation);
    void UpdateReservation(Reservation Reservation);
}