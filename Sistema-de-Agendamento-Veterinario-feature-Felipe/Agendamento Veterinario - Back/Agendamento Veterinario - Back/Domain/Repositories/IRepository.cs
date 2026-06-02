using System.Collections.Generic;
using System.Threading.Tasks;

namespace Agendamento_Veterinario___Back.Domain.Repositories
{
    public interface IRepository<TEntity, TKey>
    {
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity?> GetByIdAsync(TKey id);
        Task<TEntity> AddAsync(TEntity entity);
        Task<TEntity?> UpdateAsync(TKey id, TEntity entity);
        Task<bool> DeleteAsync(TKey id);
    }
}
