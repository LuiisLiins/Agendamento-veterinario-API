using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Agendamento_Veterinario___Back.Domain.Entities;
using Agendamento_Veterinario___Back.Domain.Repositories;

namespace Agendamento_Veterinario___Back.Repositories
{
    public class ClientesRepository : IRepository<Clientes, int>
    {
        public Task<Clientes> AddAsync(Clientes cliente)
        {
            cliente.Id = InMemoryDatabase.Clientes.Count > 0
                ? InMemoryDatabase.Clientes.Max(x => x.Id) + 1
                : 1;

            InMemoryDatabase.Clientes.Add(cliente);
            return Task.FromResult(cliente);
        }

        public Task<bool> DeleteAsync(int id)
        {
            var cliente = InMemoryDatabase.Clientes.FirstOrDefault(x => x.Id == id);
            if (cliente is null)
                return Task.FromResult(false);

            InMemoryDatabase.Clientes.Remove(cliente);
            return Task.FromResult(true);
        }

        public Task<IEnumerable<Clientes>> GetAllAsync()
        {
            return Task.FromResult(InMemoryDatabase.Clientes.AsEnumerable());
        }

        public Task<Clientes?> GetByIdAsync(int id)
        {
            var cliente = InMemoryDatabase.Clientes.FirstOrDefault(x => x.Id == id);
            return Task.FromResult(cliente);
        }

        public Task<Clientes?> UpdateAsync(int id, Clientes cliente)
        {
            var existing = InMemoryDatabase.Clientes.FirstOrDefault(x => x.Id == id);
            if (existing is null)
                return Task.FromResult<Clientes?>(null);

            existing.Nome = cliente.Nome;
            existing.CPF = cliente.CPF;
            existing.Email = cliente.Email;
            existing.Telefone = cliente.Telefone;
            existing.Endereco = cliente.Endereco;
            existing.Cidade = cliente.Cidade;
            existing.Estado = cliente.Estado;
            existing.CEP = cliente.CEP;
            existing.DataAtualizacao = DateTime.UtcNow;
            existing.Ativo = cliente.Ativo;

            return Task.FromResult<Clientes?>(existing);
        }
    }
}

