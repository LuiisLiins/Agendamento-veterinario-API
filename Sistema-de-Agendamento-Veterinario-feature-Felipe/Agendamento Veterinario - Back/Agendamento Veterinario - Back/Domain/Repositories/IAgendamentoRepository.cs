using System.Collections.Generic;
using System.Threading.Tasks;
using Agendamento_Veterinario___Back.Domain.Entities;

namespace Agendamento_Veterinario___Back.Domain.Repositories
{
    public interface IAgendamentoRepository : IRepository<Agendamento, int>
    {
        Task<IEnumerable<Agendamento>> GetByClienteIdAsync(int clienteId);
        Task<IEnumerable<Agendamento>> GetByVeterinarioIdAsync(int veterinarioId);
    }
}

