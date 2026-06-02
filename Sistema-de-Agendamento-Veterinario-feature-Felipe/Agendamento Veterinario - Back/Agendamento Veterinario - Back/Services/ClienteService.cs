using System.Collections.Generic;
using System.Threading.Tasks;
using Agendamento_Veterinario___Back.Domain.Entities;
using Agendamento_Veterinario___Back.Domain.Repositories;
using Agendamento_Veterinario___Back.Domain.Services;

namespace Agendamento_Veterinario___Back.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IRepository<Clientes, int> _repository;

        public ClienteService(IRepository<Clientes, int> repository)
        {
            _repository = repository;
        }

        public Task<Clientes> CreateAsync(Clientes cliente)
        {
            return _repository.AddAsync(cliente);
        }

        public Task<bool> DeleteAsync(int id)
        {
            return _repository.DeleteAsync(id);
        }

        public Task<IEnumerable<Clientes>> GetAllAsync()
        {
            return _repository.GetAllAsync();
        }

        public Task<Clientes?> GetByIdAsync(int id)
        {
            return _repository.GetByIdAsync(id);
        }

        public Task<Clientes?> UpdateAsync(int id, Clientes cliente)
        {
            return _repository.UpdateAsync(id, cliente);
        }
    }
}

