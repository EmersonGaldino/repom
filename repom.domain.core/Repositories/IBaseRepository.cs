namespace repom.domain.core.Repositories;

public interface IBaseRepository<TEntity> : IDisposable where TEntity : class
{
    Task<TEntity> GetByIdAsync(Guid id);
    Task<IList<TEntity>> GetAllAsync();
    Task AddOrUpdateAsync(TEntity model);
}