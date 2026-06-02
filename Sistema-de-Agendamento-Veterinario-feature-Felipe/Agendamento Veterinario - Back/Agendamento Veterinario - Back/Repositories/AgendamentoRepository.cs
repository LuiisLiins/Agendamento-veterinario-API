using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Agendamento_Veterinario___Back.Domain.Entities;
using Agendamento_Veterinario___Back.Domain.Repositories;

namespace Agendamento_Veterinario___Back.Repositories
{
    public class AgendamentoRepository : IAgendamentoRepository
    {
        public Task<Agendamento> AddAsync(Agendamento agendamento)
        {
            agendamento.Id = InMemoryDatabase.Agendamentos.Count > 0
                ? InMemoryDatabase.Agendamentos.Max(x => x.Id) + 1
                : 1;

            InMemoryDatabase.Agendamentos.Add(agendamento);
            return Task.FromResult(agendamento);
        }

        public Task<bool> DeleteAsync(int id)
        {
            var agendamento = InMemoryDatabase.Agendamentos.FirstOrDefault(x => x.Id == id);
            if (agendamento is null)
                return Task.FromResult(false);

            InMemoryDatabase.Agendamentos.Remove(agendamento);
            return Task.FromResult(true);
        }

        public Task<IEnumerable<Agendamento>> GetAllAsync()
        {
            return Task.FromResult(InMemoryDatabase.Agendamentos.AsEnumerable());
        }

        public Task<IEnumerable<Agendamento>> GetByClienteIdAsync(int clienteId)
        {
            var agendamentos = InMemoryDatabase.Agendamentos.Where(x => x.ClienteId == clienteId);
            return Task.FromResult(agendamentos);
        }

        public Task<IEnumerable<Agendamento>> GetByVeterinarioIdAsync(int veterinarioId)
        {
            var agendamentos = InMemoryDatabase.Agendamentos.Where(x => x.VeterinarioId == veterinarioId);
            return Task.FromResult(agendamentos);
        }

        public Task<Agendamento?> GetByIdAsync(int id)
        {
            var agendamento = InMemoryDatabase.Agendamentos.FirstOrDefault(x => x.Id == id);
            return Task.FromResult(agendamento);
        }

        public Task<Agendamento?> UpdateAsync(int id, Agendamento agendamento)
        {
            var existing = InMemoryDatabase.Agendamentos.FirstOrDefault(x => x.Id == id);
            if (existing is null)
                return Task.FromResult<Agendamento?>(null);

            existing.ClienteId = agendamento.ClienteId;
            existing.PetId = agendamento.PetId;
            existing.VeterinarioId = agendamento.VeterinarioId;
            existing.DataHoraAgendamento = agendamento.DataHoraAgendamento;
            existing.DataHoraFim = agendamento.DataHoraFim;
            existing.TipoServico = agendamento.TipoServico;
            existing.Descricao = agendamento.Descricao;
            existing.Valor = agendamento.Valor;
            existing.Observacoes = agendamento.Observacoes;
            existing.DataAtualizacao = DateTime.UtcNow;
            existing.Ativo = agendamento.Ativo;

            return Task.FromResult<Agendamento?>(existing);
        }
    }
}

