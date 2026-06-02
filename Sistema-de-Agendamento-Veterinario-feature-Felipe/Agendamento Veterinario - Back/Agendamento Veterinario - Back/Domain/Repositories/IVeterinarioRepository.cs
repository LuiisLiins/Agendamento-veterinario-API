using System.Collections.Generic;
using System.Threading.Tasks;
using Agendamento_Veterinario___Back.Domain.Entities;

namespace Agendamento_Veterinario___Back.Domain.Repositories
{
    public interface IVeterinarioRepository : IRepository<Veterinario, int>
    {
    }
}

