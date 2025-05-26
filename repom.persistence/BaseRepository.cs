using Microsoft.EntityFrameworkCore;
using repom.domain.core.Entity;
using repom.domain.core.Repositories;
using repom.persistence.Context;

namespace repom.persistence;

public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity
{
    protected readonly ContextDb context;
    protected DbSet<TEntity> DbSet;

    public BaseRepository(ContextDb context)
    {
        this.context = context;
        DbSet = context.Set<TEntity>();
    }

    public void Dispose() => GC.SuppressFinalize(this);

    public async Task SaveChanges()
    {
        await context.SaveChangesAsync();
    }

    public async Task Add(TEntity model)
    {
        await DbSet.AddAsync(model);
        await SaveChanges();
    }

    public async Task<bool> Delete(TEntity model)
    {
        DbSet.Remove(model);
        await SaveChanges();
        return true;
    }

    public async Task<IList<TEntity>> GetAllAsync() => await DbSet.ToListAsync();
    public async Task<TEntity> GetByIdAsync(Guid id) => await DbSet.FindAsync(id);

    public async Task<bool> Update(TEntity model)
    {
        DbSet.Update(model);
        await SaveChanges();
        return true;
    }


    public async Task AddOrUpdateAsync(TEntity model)
    {
        if (string.IsNullOrEmpty(model.id.ToString()))
            await Add(model);
        else
            await Update(model);
    }
}