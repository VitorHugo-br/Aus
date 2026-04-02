using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using ProjetoAus.Data.Context;
using ProjetoAus.Data.interfaces;
using ProjetoAus.Models;
using ProjetoAus.Models.Interfaces;

namespace ProjetoAus.Data.Repositories;

public class RepositoryBase<TEntity>(AusDbContext ausDbContext) : IRepositoryBase<TEntity>
    where TEntity : Entity
{
    private readonly DbSet<TEntity> _dbSet = ausDbContext.Set<TEntity>();

    public async Task<List<TEntity>> GetAllAsync(
        Expression<Func<TEntity, bool>>? filter = null,
        int page = 1,
        int pageSize = 10
    )
    {
        var query = _dbSet.AsQueryable();


        if (filter != null)
        {
            query = query
                .Where(filter)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .AsNoTracking();
        }
        else
        {
            query = query
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .AsNoTracking();
        }

        return await query.ToListAsync();
    }

    public async Task<TEntity?> GetByIdAsync(Guid id)
    {
        return await _dbSet.FindAsync(id);
    }

    public async Task CreateAsync(TEntity entity)
    {
        await _dbSet.AddAsync(entity);
        await ausDbContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(TEntity entity)
    {
        _dbSet.Update(entity);
        await ausDbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(TEntity entity)
    {
        _dbSet.Remove(entity);
        await ausDbContext.SaveChangesAsync();
    }
}