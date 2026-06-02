using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Agendamento_Veterinario___Back.Domain.Entities;
using Agendamento_Veterinario___Back.Domain.Repositories;

namespace Agendamento_Veterinario___Back.Repositories
{
    public class VeterinarioRepository : IVeterinarioRepository
    {
        public Task<Veterinario> AddAsync(Veterinario veterinario)
        {
            veterinario.Id = InMemoryDatabase.Veterinarios.Count > 0
                ? InMemoryDatabase.Veterinarios.Max(x => x.Id) + 1
                : 1;

            InMemoryDatabase.Veterinarios.Add(veterinario);
            return Task.FromResult(veterinario);
        }

        public Task<bool> DeleteAsync(int id)
        {
            var veterinario = InMemoryDatabase.Veterinarios.FirstOrDefault(x => x.Id == id);
            if (veterinario is null)
                return Task.FromResult(false);

            InMemoryDatabase.Veterinarios.Remove(veterinario);
            return Task.FromResult(true);
        }

        public Task<IEnumerable<Veterinario>> GetAllAsync()
        {
            return Task.FromResult(InMemoryDatabase.Veterinarios.AsEnumerable());
        }

        public Task<Veterinario?> GetByIdAsync(int id)
        {
            var veterinario = InMemoryDatabase.Veterinarios.FirstOrDefault(x => x.Id == id);
            return Task.FromResult(veterinario);
        }

        public Task<Veterinario?> UpdateAsync(int id, Veterinario veterinario)
        {
            var existing = InMemoryDatabase.Veterinarios.FirstOrDefault(x => x.Id == id);
            if (existing is null)
                return Task.FromResult<Veterinario?>(null);

            existing.Nome = veterinario.Nome;
            existing.CRMV = veterinario.CRMV;
            existing.Email = veterinario.Email;
            existing.Telefone = veterinario.Telefone;
            existing.Especialidade = veterinario.Especialidade;
            existing.DataAtualizacao = DateTime.UtcNow;
            existing.Ativo = veterinario.Ativo;

            return Task.FromResult<Veterinario?>(existing);
        }
    }
}

