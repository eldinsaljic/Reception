using System;
using Hotel.Server.Data;
using Hotel.Server.Repository.Contracts;

namespace Hotel.Server.Repositories;

public class RepositoryManager : IRepositoryManager
{
    private readonly Lazy<ICategoryRepository> _lazyCategoryRepository;
    private readonly Lazy<IReservationRepository> _lazyReservationRepository;
    private readonly Lazy<IRoomRepository> _lazyRoomRepository;
    private readonly Lazy<IUnitOfWork> _lazyUnitOfWork;

    public RepositoryManager(DataContext context)
    {
        _lazyCategoryRepository = new Lazy<ICategoryRepository>(() => new CategoryRepository(context));
        _lazyReservationRepository = new Lazy<IReservationRepository>(() => new ReservationRepository(context));
        _lazyRoomRepository = new Lazy<IRoomRepository>(() => new RoomRepository(context));
        _lazyUnitOfWork = new Lazy<IUnitOfWork>(() => new UnitOfWork(context));
    }

    public ICategoryRepository CategoryRepository => _lazyCategoryRepository.Value;
    public IReservationRepository ReservationRepository => _lazyReservationRepository.Value;
    public IRoomRepository RoomRepository => _lazyRoomRepository.Value;
    public IUnitOfWork UnitOfWork => _lazyUnitOfWork.Value;
}