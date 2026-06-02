using System.Collections.Generic;
using System.Threading.Tasks;
using Agendamento_Veterinario___Back.Domain.Entities;

namespace Agendamento_Veterinario___Back.Domain.Services
{
    public interface IPetService
    {
        Task<IEnumerable<Pet>> GetAllAsync();
        Task<Pet?> GetByIdAsync(int id);
        Task<IEnumerable<Pet>> GetByClienteIdAsync(int clienteId);
        Task<Pet> CreateAsync(Pet pet);
        Task<Pet?> UpdateAsync(int id, Pet pet);
        Task<bool> DeleteAsync(int id);
    }
}

