using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using RetroRemedy.Core.Common;

namespace RetroRemedy.Infrastructure.Common;

public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
{
    protected readonly DbContext _context;
    protected readonly DbSet<TEntity> _dbSet;

    public BaseRepository(DbContext context)
    {
        _context = context;
        _dbSet = _context.Set<TEntity>();
    }

    public async Task<TEntity> GetByIdAsync(long id, CancellationToken cancellationToken = default)
    {
        return await _dbSet.FindAsync( id , cancellationToken);
    }

    public async Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> expression, CancellationToken cancellationToken = default)
    {
        return await _dbSet.AsNoTracking().AnyAsync(expression, cancellationToken);
    }

    public async Task<IEnumerable<TEntity>> GetManyAsyncBy(
        Expression<Func<TEntity, bool>> expression,
        CancellationToken cancellationToken = default,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
        string includes = null)
    {
        IQueryable<TEntity> query = _dbSet.AsNoTracking().Where(expression);

        if (!string.IsNullOrEmpty(includes))
        {
            foreach (var include in includes.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(include);
            }
        }

        if (orderBy != null)
        {
            return await orderBy(query).ToListAsync(cancellationToken);
        }

        return await query.ToListAsync(cancellationToken);
    }

    public async Task<IEnumerable<TEntity>> GetAllAsync(
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, 
        CancellationToken cancellationToken = default)
    {
        IQueryable<TEntity> query = _dbSet.AsNoTracking();

        if (orderBy != null)
        {
            query = orderBy(query);
        }

        return await query.ToListAsync(cancellationToken);
    }
    
    public async Task<PaginatedResult<TEntity>> GetPagedAsync(
        int pageIndex, 
        int pageSize, 
        Expression<Func<TEntity, bool>> filter = null, 
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, 
        string includes = null,
        CancellationToken cancellationToken = default)
    {
        IQueryable<TEntity> query = _dbSet.AsNoTracking();

        if (filter != null)
        {
            query = query.Where(filter);
        }

        if (!string.IsNullOrEmpty(includes))
        {
            foreach (var include in includes.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(include);
            }
        }

        var totalCount = await query.CountAsync(cancellationToken);

        if (orderBy != null)
        {
            query = orderBy(query);
        }

        var data = await query
            .Skip((pageIndex - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync(cancellationToken);

        return new PaginatedResult<TEntity>(pageIndex, pageSize, totalCount, data);
    }

    public async Task<TEntity> CreateAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        await _dbSet.AddAsync(entity, cancellationToken);
        return entity;
    }

    public async Task CreateManyAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default)
    {
        await _dbSet.AddRangeAsync(entities, cancellationToken);
    }

    public void UpdateAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        _dbSet.Update(entity);
    }

    public void UpdateRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default)
    {
        _dbSet.UpdateRange(entities);
    }

    public async Task UpdateFieldByIdAsync(long id, string fieldName, object newValue, CancellationToken cancellationToken = default)
    {
        var entity = await _dbSet.FindAsync(new object[] { id }, cancellationToken);
        if (entity != null)
        {
            _context.Entry(entity).Property(fieldName).CurrentValue = newValue;
        }
    }

    public void DeleteAsync(TEntity entity)
    {
        _dbSet.Remove(entity);
    }

    public void DeleteManyAsync(IEnumerable<TEntity> entities)
    {
        _dbSet.RemoveRange(entities);
    }

    public async Task<bool> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return await _context.SaveChangesAsync(cancellationToken) > 0;
    }
}

