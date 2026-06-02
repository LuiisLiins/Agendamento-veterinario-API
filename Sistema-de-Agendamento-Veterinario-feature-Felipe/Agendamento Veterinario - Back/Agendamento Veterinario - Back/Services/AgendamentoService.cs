using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Agendamento_Veterinario___Back.Domain.Entities;
using Agendamento_Veterinario___Back.Domain.Repositories;
using Agendamento_Veterinario___Back.Domain.Services;

namespace Agendamento_Veterinario___Back.Services
{
    public class AgendamentoService : IAgendamentoService
    {
        private readonly IRepository<Agendamento, int> _repository;

        public AgendamentoService(IRepository<Agendamento, int> repository)
        {
            _repository = repository;
        }

        public Task<Agendamento> CreateAsync(Agendamento agendamento)
        {
            return _repository.AddAsync(agendamento);
        }

        public Task<bool> DeleteAsync(int id)
        {
            return _repository.DeleteAsync(id);
        }

        public Task<IEnumerable<Agendamento>> GetAllAsync()
        {
            return _repository.GetAllAsync();
        }

        public async Task<IEnumerable<Agendamento>> GetByClienteIdAsync(int clienteId)
        {
            var all = await _repository.GetAllAsync();
            return all.Where(a => a.ClienteId == clienteId);
        }

        public async Task<IEnumerable<Agendamento>> GetByVeterinarioIdAsync(int veterinarioId)
        {
            var all = await _repository.GetAllAsync();
            return all.Where(a => a.VeterinarioId == veterinarioId);
        }

        public Task<Agendamento?> GetByIdAsync(int id)
        {
            return _repository.GetByIdAsync(id);
        }

        public Task<Agendamento?> UpdateAsync(int id, Agendamento agendamento)
        {
            return _repository.UpdateAsync(id, agendamento);
        }
    }
}

