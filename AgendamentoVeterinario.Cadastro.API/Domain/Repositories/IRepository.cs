using System.Collections.Generic;
using System.Threading.Tasks;

namespace AgendamentoVeterinario.Cadastro.API.Domain.Repositories
{
    public interface IRepository<TEntity, TId> where TEntity : class
    {
        Task<TEntity> AddAsync(TEntity entity);
        Task<TEntity?> GetByIdAsync(TId id);
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity?> UpdateAsync(TId id, TEntity entity);
    }
}