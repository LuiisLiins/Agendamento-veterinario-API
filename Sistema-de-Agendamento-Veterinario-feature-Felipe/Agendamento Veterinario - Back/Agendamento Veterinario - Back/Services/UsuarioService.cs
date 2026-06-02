using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Agendamento_Veterinario___Back.Domain.Entities;
using Agendamento_Veterinario___Back.Domain.Repositories;

namespace Agendamento_Veterinario___Back.Domain.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IRepository<Usuario, System.Guid> _repository;

        public UsuarioService(IRepository<Usuario, System.Guid> repository)
        {
            _repository = repository;
        }

        public Task<Usuario> CreateAsync(Usuario usuario)
        {
            return _repository.AddAsync(usuario);
        }

        public Task<bool> DeleteAsync(System.Guid id)
        {
            return _repository.DeleteAsync(id);
        }

        public Task<IEnumerable<Usuario>> GetAllAsync()
        {
            return _repository.GetAllAsync();
        }

        public async Task<Usuario?> GetByEmailAsync(string email)
        {
            var all = await _repository.GetAllAsync();
            return all.FirstOrDefault(u => u.Email == email);
        }

        public Task<Usuario?> GetByIdAsync(System.Guid id)
        {
            return _repository.GetByIdAsync(id);
        }

        public Task<Usuario?> UpdateAsync(System.Guid id, Usuario usuario)
        {
            return _repository.UpdateAsync(id, usuario);
        }
    }
}

