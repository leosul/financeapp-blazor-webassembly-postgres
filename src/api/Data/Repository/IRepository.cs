using System.Linq.Expressions;
using FinanceApp.Api.Models;

namespace FinanceApp.Api.Data.Repository;

public interface IRepository<TEntity> : IDisposable where TEntity : EntityBase
{
    IUnitOfWork UnitOfWork { get; }
    void Add(TEntity entity);
    void Add(IEnumerable<TEntity> entities);
    Task<TEntity> GetById(Guid id);
    Task<List<TEntity>> GetAll();
    void Update(TEntity entity);
    void Remove(Guid id);
    void Remove(IEnumerable<TEntity> entities);
    Task<List<TEntity>> Find(Expression<Func<TEntity, bool>> predicate);
}
