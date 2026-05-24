using AgendamentoVeterinario.Cadastro.API.Domain.Entities;
using AgendamentoVeterinario.Cadastro.API.Domain.Repositories;

namespace AgendamentoVeterinario.Cadastro.API.Application.UseCases
{
    public class DesativarUsuarioUseCase
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public DesativarUsuarioUseCase(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task ExecutarAsync(Guid id)
        {
            var usuario = await _usuarioRepository.GetByIdAsync(id);
            if (usuario is null) throw new Exception("Usuário não encontrado.");

            usuario.Desativar();

            await _usuarioRepository.UpdateAsync(id, usuario);
        }
    }
}
