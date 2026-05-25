using System.Threading.Tasks;

namespace AgendamentoVeterinario.Cadastro.API.Domain.Repositories
{
    public interface IUnitOfWork
    {
        Task BeginTransactionAsync();
        Task CommitAsync();
        Task RollbackAsync();
    }
}