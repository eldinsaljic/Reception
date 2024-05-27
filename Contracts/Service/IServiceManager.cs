namespace Hotel.Server.Contracts.Service;

public interface IServiceManager
{
    ICategoryService CategoryService { get; }
    IRoomService RoomService { get; }
    IReservationService ReservationService { get; }
}