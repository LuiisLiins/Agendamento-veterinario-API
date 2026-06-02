using System.Collections.Generic;
using System.Threading.Tasks;
using Agendamento_Veterinario___Back.Domain.Entities;
using Agendamento_Veterinario___Back.Domain.Repositories;
using Agendamento_Veterinario___Back.Domain.Services;

namespace Agendamento_Veterinario___Back.Services
{
    public class VeterinarioService : IVeterinarioService
    {
        private readonly IRepository<Veterinario, int> _repository;

        public VeterinarioService(IRepository<Veterinario, int> repository)
        {
            _repository = repository;
        }

        public Task<Veterinario> CreateAsync(Veterinario veterinario)
        {
            return _repository.AddAsync(veterinario);
        }

        public Task<bool> DeleteAsync(int id)
        {
            return _repository.DeleteAsync(id);
        }

        public Task<IEnumerable<Veterinario>> GetAllAsync()
        {
            return _repository.GetAllAsync();
        }

        public Task<Veterinario?> GetByIdAsync(int id)
        {
            return _repository.GetByIdAsync(id);
        }

        public Task<Veterinario?> UpdateAsync(int id, Veterinario veterinario)
        {
            return _repository.UpdateAsync(id, veterinario);
        }
    }
}

