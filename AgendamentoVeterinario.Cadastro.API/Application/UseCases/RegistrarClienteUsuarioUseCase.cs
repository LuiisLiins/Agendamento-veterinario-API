using AgendamentoVeterinario.Cadastro.API.Domain.Entities;
using AgendamentoVeterinario.Cadastro.API.Domain.Repositories;
using System;
using System.Threading.Tasks;

namespace AgendamentoVeterinario.Cadastro.API.Application.UseCases
{
    public class RegistrarClienteUsuarioUseCase
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IClienteRepository _clienteRepository;
        private readonly IUnitOfWork _unitOfWork;

        public RegistrarClienteUsuarioUseCase(
            IUsuarioRepository usuarioRepository,
            IClienteRepository clienteRepository,
            IUnitOfWork unitOfWork)
        {
            _usuarioRepository = usuarioRepository;
            _clienteRepository = clienteRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Cliente> ExecutarAsync(string nome, string email, string senhaRaw, string cpf, string telefone, string endereco, string cidade, string estado, string cep)
        {
            var usuarioExistente = await _usuarioRepository.GetByEmailAsync(email);
            if (usuarioExistente != null) throw new InvalidOperationException("E-mail já cadastrado no sistema.");

            var clienteExistente = await _clienteRepository.GetByCpfAsync(cpf);
            if (clienteExistente != null) throw new InvalidOperationException("CPF já cadastrado no sistema.");

            await _unitOfWork.BeginTransactionAsync();

            try
            {
                var senhaHash = BCrypt.Net.BCrypt.HashPassword(senhaRaw);
                var novoUsuario = new Usuario(nome, email, senhaHash);

                await _usuarioRepository.AddAsync(novoUsuario);

                var novoCliente = new Cliente(cpf, telefone, endereco, cidade, estado, cep, novoUsuario.Id);

                await _clienteRepository.AddAsync(novoCliente);

                await _unitOfWork.CommitAsync();

                return novoCliente;
            }
            catch
            {
                await _unitOfWork.RollbackAsync();
                throw;
            }
        }
    }
}