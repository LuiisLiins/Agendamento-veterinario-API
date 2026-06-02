using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Agendamento_Veterinario___Back.Domain.Entities;
using Agendamento_Veterinario___Back.Domain.Repositories;
using Agendamento_Veterinario___Back.Domain.Services;

namespace Agendamento_Veterinario___Back.Services
{
    public class PetService : IPetService
    {
        private readonly IRepository<Pet, int> _repository;

        public PetService(IRepository<Pet, int> repository)
        {
            _repository = repository;
        }

        public Task<Pet> CreateAsync(Pet pet)
        {
            return _repository.AddAsync(pet);
        }

        public Task<bool> DeleteAsync(int id)
        {
            return _repository.DeleteAsync(id);
        }

        public Task<IEnumerable<Pet>> GetAllAsync()
        {
            return _repository.GetAllAsync();
        }

        public Task<Pet?> GetByIdAsync(int id)
        {
            return _repository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Pet>> GetByClienteIdAsync(int clienteId)
        {
            var all = await _repository.GetAllAsync();
            return all.Where(p => p.ClienteId == clienteId);
        }

        public Task<Pet?> UpdateAsync(int id, Pet pet)
        {
            return _repository.UpdateAsync(id, pet);
        }
    }
}

