using System.Collections.Generic;
using System.Threading.Tasks;
using Agendamento_Veterinario___Back.Domain.Entities;

namespace Agendamento_Veterinario___Back.Domain.Repositories
{
    public interface IPetRepository : IRepository<Pet, int>
    {
        Task<IEnumerable<Pet>> GetByClienteIdAsync(int clienteId);
    }
}

