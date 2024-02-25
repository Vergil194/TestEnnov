using Domain.Entities;
using System.Linq.Expressions;

namespace Domain
{
    public interface IGeneriqueRepository<TEntity> where TEntity : BaseEntity
    {
        Task<List<TEntity>> GetAsync(Expression<Func<TEntity, bool>> query, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? sort = default, int? nbToTake = null, CancellationToken cancellationToken = default);
        Task<List<TResult>> GetAsync<TResult>(Expression<Func<TEntity, bool>> filter, Expression<Func<TEntity, TResult>> projection, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? sort = default, int? nbToTake = null, CancellationToken cancellationToken = default);
        Task<TEntity?> GetByIdAsync<TId>(TId id, CancellationToken cancellationToken = default) where TId : notnull;
        Task<TResult?> GetByIdAsync<TId, TResult>(TId id, Func<TEntity, TResult> projection, CancellationToken cancellationToken = default) where TId : notnull;
        Task<bool> AddAsync(TEntity entity, CancellationToken cancellationToken = default);
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
        Task<List<TEntity>> GetAllAsync();
        Task<bool> DeleteAsync(TEntity entity, CancellationToken cancellationToken = default);
    }
}
