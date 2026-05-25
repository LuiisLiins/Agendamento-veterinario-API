using System.Threading.Tasks;
using AgendamentoVeterinario.Cadastro.API.Domain.Entities;

namespace AgendamentoVeterinario.Cadastro.API.Domain.Repositories
{
    public interface IClienteRepository : IRepository<Cliente, int>
    {
        Task<Cliente?> GetByCpfAsync(string cpf);
    }
}