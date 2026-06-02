using System.Collections.Generic;
using System.Threading.Tasks;
using Agendamento_Veterinario___Back.Domain.Entities;

namespace Agendamento_Veterinario___Back.Domain.Services
{
    public interface IVeterinarioService
    {
        Task<IEnumerable<Veterinario>> GetAllAsync();
        Task<Veterinario?> GetByIdAsync(int id);
        Task<Veterinario> CreateAsync(Veterinario veterinario);
        Task<Veterinario?> UpdateAsync(int id, Veterinario veterinario);
        Task<bool> DeleteAsync(int id);
    }
}

