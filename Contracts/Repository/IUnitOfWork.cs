using System.Threading.Tasks;

namespace Hotel.Server.Repository.Contracts;

public interface IUnitOfWork
{
    Task<int> SaveChangesAsync();
}