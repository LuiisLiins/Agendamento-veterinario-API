using System.Collections.Generic;
using System.Threading.Tasks;
using AgendamentoVeterinario.Consultas.API.Domain.Entities;

namespace AgendamentoVeterinario.Consultas.API.Domain.Repositories
{
    public interface IAgendamentoRepository : IRepository<Agendamento, int>
    {
        Task<IEnumerable<Agendamento>> GetByClienteIdAsync(int clienteId);
        Task<IEnumerable<Agendamento>> GetByVeterinarioIdAsync(int veterinarioId);
    }
}