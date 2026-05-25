    using System.Threading.Tasks;
    using AgendamentoVeterinario.Consultas.API.Domain.Entities;

    namespace AgendamentoVeterinario.Consultas.API.Domain.Repositories
    {
        public interface IVeterinarioRepository : IRepository<Veterinario, int>
        {
        }
    }