using System.Linq.Expressions;

namespace ProjetoAus.Models.Interfaces;

public interface IRepositoryBase<TEntity> where TEntity : Entity
{
    Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>>? filter = null, int page = 1, int pageSize = 10);
    Task<TEntity?> GetByIdAsync(Guid id);
    Task CreateAsync(TEntity entity);
    Task UpdateAsync(TEntity entity);
    Task DeleteAsync(TEntity entity);
}