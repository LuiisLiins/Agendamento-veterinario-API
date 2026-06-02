using System.Collections.Generic;
using System.Threading.Tasks;
using Agendamento_Veterinario___Back.Domain.Entities;

namespace Agendamento_Veterinario___Back.Domain.Services
{
    public interface IAgendamentoService
    {
        Task<IEnumerable<Agendamento>> GetAllAsync();
        Task<Agendamento?> GetByIdAsync(int id);
        Task<IEnumerable<Agendamento>> GetByClienteIdAsync(int clienteId);
        Task<IEnumerable<Agendamento>> GetByVeterinarioIdAsync(int veterinarioId);
        Task<Agendamento> CreateAsync(Agendamento agendamento);
        Task<Agendamento?> UpdateAsync(int id, Agendamento agendamento);
        Task<bool> DeleteAsync(int id);
    }
}

