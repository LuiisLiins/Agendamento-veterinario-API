using System;
using System.Threading.Tasks;
using AgendamentoVeterinario.Cadastro.API.Domain.Entities;

namespace AgendamentoVeterinario.Cadastro.API.Domain.Repositories
{
    public interface IUsuarioRepository : IRepository<Usuario, Guid>
    {
        Task<Usuario?> GetByEmailAsync(string email);
    }
}