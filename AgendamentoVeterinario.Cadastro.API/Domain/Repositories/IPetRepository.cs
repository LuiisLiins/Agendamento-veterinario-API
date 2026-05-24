using System.Collections.Generic;
using System.Threading.Tasks;
using AgendamentoVeterinario.Cadastro.API.Domain.Entities;

namespace AgendamentoVeterinario.Cadastro.API.Domain.Repositories
{
    public interface IPetRepository : IRepository<Pet, int>
    {
        Task<IEnumerable<Pet>> GetByClienteIdAsync(int clienteId);
        Task<bool> ExisteConsultaFuturaParaOPetAsync(int petId);
    }
}