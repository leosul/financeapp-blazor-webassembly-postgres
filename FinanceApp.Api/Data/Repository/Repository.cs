using System.Linq.Expressions;
using FinanceApp.Api.Data.Context;
using FinanceApp.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace FinanceApp.Api.Data.Repository;

public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : EntityBase, new()
{
    protected readonly FinanceDbContext Db;
    protected readonly DbSet<TEntity> DbSet;
    protected Repository(FinanceDbContext db)
    {
        Db = db;
        DbSet = db.Set<TEntity>();
    }

    public IUnitOfWork UnitOfWork => Db;
    public virtual async Task<List<TEntity>> Find(Expression<Func<TEntity, bool>> predicate)
    {
        return await DbSet.AsNoTracking().Where(predicate).ToListAsync();
    }

    public virtual async Task<List<TEntity>> GetAll()
    {
        return await DbSet.ToListAsync();
    }

    public virtual async Task<TEntity> GetById(Guid id)
    {
        return await DbSet.FindAsync(id);
    }

    public virtual void Add(TEntity entity)
    {
        DbSet.Add(entity);
    }

    public virtual void Add(IEnumerable<TEntity> entities)
    {
        DbSet.AddRange(entities);
    }

    public virtual void Update(TEntity entity)
    {
        DbSet.Update(entity);
    }

    public virtual void Remove(Guid id)
    {
        DbSet.Remove(new TEntity { Id = id });
    }

    public virtual void Remove(IEnumerable<TEntity> entities)
    {
        DbSet.RemoveRange(entities);
    }

    private bool _disposed = false;
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
    protected virtual void Dispose(bool disposing)
    {
        if (!_disposed)
        {
            if (disposing)
                Db?.Dispose();

            _disposed = true;
        }
    }
}
