using System.Threading.Tasks;

namespace AgendamentoVeterinario.Consultas.API.Domain.Repositories
{
    public interface IUnitOfWork
    {
        Task BeginTransactionAsync();
        Task CommitAsync();
        Task RollbackAsync();
    }
}