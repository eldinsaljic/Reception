using Hotel.Server.Contracts.Service;
using Hotel.Server.Repository.Contracts;

namespace Hotel.Server.Services;

public class ServiceManager : IServiceManager
{
    private readonly Lazy<ICategoryService> _lazyCategoryService;
    private readonly Lazy<IReservationService> _lazyReservationService;
    private readonly Lazy<IRoomService> _lazyRoomService;

    public ServiceManager(IRepositoryManager repositoryManager)
    {
        _lazyCategoryService = new Lazy<ICategoryService>(() => new CategoryService(repositoryManager));
        _lazyRoomService = new Lazy<IRoomService>(() => new RoomService(repositoryManager));
        _lazyReservationService = new Lazy<IReservationService>(() => new ReservationService(repositoryManager));
    }

    public ICategoryService CategoryService => _lazyCategoryService.Value;
    public IRoomService RoomService => _lazyRoomService.Value;
    public IReservationService ReservationService => _lazyReservationService.Value;
}