using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Agendamento_Veterinario___Back.Domain.Entities;
using Agendamento_Veterinario___Back.Domain.Repositories;

namespace Agendamento_Veterinario___Back.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        public Task<Usuario> AddAsync(Usuario usuario)
        {
            usuario.Id = Guid.NewGuid();
            InMemoryDatabase.Usuarios.Add(usuario);
            return Task.FromResult(usuario);
        }

        public Task<bool> DeleteAsync(Guid id)
        {
            var usuario = InMemoryDatabase.Usuarios.FirstOrDefault(x => x.Id == id);
            if (usuario is null)
                return Task.FromResult(false);

            InMemoryDatabase.Usuarios.Remove(usuario);
            return Task.FromResult(true);
        }

        public Task<IEnumerable<Usuario>> GetAllAsync()
        {
            return Task.FromResult(InMemoryDatabase.Usuarios.AsEnumerable());
        }

        public Task<Usuario?> GetByEmailAsync(string email)
        {
            var usuario = InMemoryDatabase.Usuarios.FirstOrDefault(x => x.Email == email);
            return Task.FromResult(usuario);
        }

        public Task<Usuario?> GetByIdAsync(Guid id)
        {
            var usuario = InMemoryDatabase.Usuarios.FirstOrDefault(x => x.Id == id);
            return Task.FromResult(usuario);
        }

        public Task<Usuario?> UpdateAsync(Guid id, Usuario usuario)
        {
            var existing = InMemoryDatabase.Usuarios.FirstOrDefault(x => x.Id == id);
            if (existing is null)
                return Task.FromResult<Usuario?>(null);

            existing.Nome = usuario.Nome;
            existing.Email = usuario.Email;
            existing.SenhaHash = usuario.SenhaHash;
            existing.Ativo = usuario.Ativo;

            return Task.FromResult<Usuario?>(existing);
        }
    }
}

