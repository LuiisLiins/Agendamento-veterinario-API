using System;
using System.Threading.Tasks;
using AgendamentoVeterinario.Cadastro.API.Domain.Repositories;

namespace AgendamentoVeterinario.Cadastro.API.Application.UseCases
{
    public class DesativarClienteUsuarioUseCase
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DesativarClienteUsuarioUseCase(
            IClienteRepository clienteRepository,
            IUsuarioRepository usuarioRepository,
            IUnitOfWork unitOfWork)
        {
            _clienteRepository = clienteRepository;
            _usuarioRepository = usuarioRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task ExecutarAsync(int clienteId)
        {
            var cliente = await _clienteRepository.GetByIdAsync(clienteId);
            if (cliente is null) throw new Exception("Cliente não encontrado.");

            var usuario = await _usuarioRepository.GetByIdAsync(cliente.UsuarioId);
            if (usuario is null) throw new Exception("Usuário vinculado não encontrado.");

            await _unitOfWork.BeginTransactionAsync();

            try
            {
                cliente.Desativar();
                usuario.Desativar();

                await _clienteRepository.UpdateAsync(clienteId, cliente);
                await _usuarioRepository.UpdateAsync(usuario.Id, usuario);

                await _unitOfWork.CommitAsync();
            }
            catch
            {
                await _unitOfWork.RollbackAsync();
                throw;
            }
        }
    }
}