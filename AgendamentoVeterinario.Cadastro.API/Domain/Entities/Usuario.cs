using AgendamentoVeterinario.Cadastro.API.Application.DTOs;
using System;

namespace AgendamentoVeterinario.Cadastro.API.Domain.Entities
{
    public class Usuario
    {
        public Guid Id { get; private set; }
        public string Nome { get; private set; } = null!;
        public string Email { get; private set; } = null!;
        public string SenhaHash { get; private set; } = null!;
        public bool Ativo { get; private set; }
        public DateTime DataCriacao { get; private set; }
        public string Tipo { get; private set; }

        public Usuario() { }

        public Usuario(string nome, string email, string senhaHash, string tipo = "Cliente")
        {
            Id = Guid.NewGuid();
            Nome = nome;
            Email = email;
            SenhaHash = senhaHash;
            Ativo = true;
            DataCriacao = DateTime.UtcNow;
            Tipo = tipo;
        }

        public void Desativar()
        {
            Ativo = false;
        }
    }
}