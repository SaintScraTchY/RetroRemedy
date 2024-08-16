using System.Linq.Expressions;

namespace RetroRemedy.Core.Common;

public interface IBaseRepository<TEntity> where TEntity : class
{
    Task<TEntity> GetByIdAsync(long id, CancellationToken cancellationToken = default);
    
    Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> expression, CancellationToken cancellationToken = default);
    
    Task<IEnumerable<TEntity>> GetManyAsyncBy(
        Expression<Func<TEntity, bool>> expression,
        CancellationToken cancellationToken = default,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
        string includes = null); 
    
    Task<IEnumerable<TEntity>> GetAllAsync(Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,CancellationToken cancellationToken = default);
    
    Task<PaginatedResult<TEntity>> GetPagedAsync(
        int pageIndex, 
        int pageSize, 
        Expression<Func<TEntity, bool>> filter = null, 
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, 
        string includes = null,
        CancellationToken cancellationToken = default);
    Task<TEntity> CreateAsync(TEntity entity, CancellationToken cancellationToken = default);
    Task CreateManyAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default);
    void UpdateAsync(TEntity entity, CancellationToken cancellationToken = default);
    void UpdateRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default);
    void DeleteAsync(TEntity entity);
    void DeleteManyAsync(IEnumerable<TEntity> entities);
    
    Task<bool> SaveChangesAsync(CancellationToken cancellationToken = default);
}
