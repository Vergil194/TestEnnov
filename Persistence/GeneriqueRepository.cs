using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
namespace Persistence
{
    public class GeneriqueRepository<TEntity> : IGeneriqueRepository<TEntity>
        where TEntity : BaseEntity
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public GeneriqueRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public virtual async Task UpdateAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            _context.Entry(entity).State = EntityState.Modified;

            await SaveChangesAsync(cancellationToken);
        }
        public virtual async Task<bool> DeleteAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            _context.Set<TEntity>().Remove(entity);

            return await SaveChangesAsync(cancellationToken) > 0;
        }

        public virtual async Task<TEntity> GetByIdAsync<TId>(TId id, CancellationToken cancellationToken = default) where TId : notnull
        {
            return await GetByIdAsync(id, x => x, cancellationToken);
        }

        public async Task<TResult> GetByIdAsync<TId, TResult>(TId id, Func<TEntity, TResult> projection, CancellationToken cancellationToken = default) where TId : notnull
        {
            var o = await _context.Set<TEntity>().FindAsync(new object[] { id }, cancellationToken: cancellationToken);
            if (o == null)
                return default;
            return projection(o);
        }


        public async Task<List<TEntity>> GetAllAsync()
        {
            var result = await _context.Set<TEntity>()
                            .ProjectTo<TEntity>(_mapper.ConfigurationProvider)
                                .ToListAsync();

            return result;
        }
        public virtual async Task<List<TEntity>> GetAsync(Expression<Func<TEntity, bool>> query, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> sort = default, int? nbToTake = null, CancellationToken cancellationToken = default)
        {
            return await GetAsync(query, x => x, sort, nbToTake, cancellationToken);
        }

        public async Task<List<TResult>> GetAsync<TResult>(Expression<Func<TEntity, bool>> filter, Expression<Func<TEntity, TResult>> projection, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> sort = default, int? nbToTake = null, CancellationToken cancellationToken = default)
        {
            var query = _context.Set<TEntity>().Where(filter);

            if (sort != null)
                query = sort(query);

            if (nbToTake.HasValue)
                query = query.Take(nbToTake.Value);

            return await query
                .Select(projection)
                .ToListAsync(cancellationToken);
        }

        public virtual async Task<bool> AddAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            _context.Set<TEntity>().Add(entity);

            return await SaveChangesAsync(cancellationToken) > 0;

        }
        public virtual async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
