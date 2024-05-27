using System.Threading.Tasks;
using Hotel.Server.Data;
using Hotel.Server.Repository.Contracts;

namespace Hotel.Server.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly DataContext _context;

    public UnitOfWork(DataContext context)
    {
        _context = context;
    }

    public Task<int> SaveChangesAsync()
    {
        return _context.SaveChangesAsync();
    }
}