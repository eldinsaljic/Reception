using System.Collections.Generic;
using System.Threading.Tasks;
using Hotel.Server.Data.Dto;
using Hotel.Server.Data.Dto.Reservation;

namespace Hotel.Server.Contracts.Service;

public interface IReservationService
{
    Task<IEnumerable<ReservationReadOnlyDto>> GetAllReservations();
    Task<ReservationReadOnlyDto> GetReservationById(int id);
    Task<ResponseDto> CreateReservation(ReservationCreateDto ReservationDto);
    Task<ResponseDto> UpdateReservation(int ReservationId, ReservationUpdateDto ReservationDto);
    Task<bool> DeleteReservation(int ReservationID);
}