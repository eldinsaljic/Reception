using System;
using System.Linq;
using System.Linq.Expressions;
using Hotel.Server.Data;
using Hotel.Server.Repository.Contracts;
using Microsoft.EntityFrameworkCore;

namespace Hotel.Server.Repositories;

public class BaseRepository<T> : IBaseRepository<T> where T : class
{
    private readonly DataContext _context;

    public BaseRepository(DataContext context)
    {
        _context = context;
    }

    public void Create(T entity)
    {
        _context.Set<T>().Add(entity);
    }

    public void Delete(T entity)
    {
        _context.Set<T>().Remove(entity);
    }

    public IQueryable<T> FindAll()
    {
        return _context.Set<T>().AsNoTracking();
    }

    public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
    {
        return _context.Set<T>().Where(expression).AsNoTracking();
    }

    public void Update(T entity)
    {
        _context.Set<T>().Update(entity);
    }
}