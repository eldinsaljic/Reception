namespace Hotel.Server.Repository.Contracts;

public interface IRepositoryManager
{
    ICategoryRepository CategoryRepository { get; }
    IReservationRepository ReservationRepository { get; }
    IRoomRepository RoomRepository { get; }
    IUnitOfWork UnitOfWork { get; }
}