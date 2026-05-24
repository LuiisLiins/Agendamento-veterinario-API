using System;
using System.Threading.Tasks;
using AgendamentoVeterinario.Cadastro.API.Domain.Entities;
using AgendamentoVeterinario.Cadastro.API.Domain.Repositories;

namespace AgendamentoVeterinario.Cadastro.API.Application.UseCases
{
    public class RegistrarUsuarioUseCase
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public RegistrarUsuarioUseCase(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task<Usuario> ExecutarAsync(string nome, string email, string senhaRaw)
        {
            var existente = await _usuarioRepository.GetByEmailAsync(email);
            if (existente != null)
            {
                throw new InvalidOperationException("E-mail ja cadastrado no sistema.");
            }

            var senhaHash = BCrypt.Net.BCrypt.HashPassword(senhaRaw);
            var novoUsuario = new Usuario(nome, email, senhaHash);

            return await _usuarioRepository.AddAsync(novoUsuario);
        }
    }
}