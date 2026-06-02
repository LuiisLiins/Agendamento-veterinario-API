using System.Collections.Generic;
using System.Threading.Tasks;
using Agendamento_Veterinario___Back.Domain.Entities;

namespace Agendamento_Veterinario___Back.Domain.Services
{
    public interface IClienteService
    {
        Task<IEnumerable<Clientes>> GetAllAsync();
        Task<Clientes?> GetByIdAsync(int id);
        Task<Clientes> CreateAsync(Clientes cliente);
        Task<Clientes?> UpdateAsync(int id, Clientes cliente);
        Task<bool> DeleteAsync(int id);
    }
}

