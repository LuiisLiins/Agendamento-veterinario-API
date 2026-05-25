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
        public DateTime? DataAtualizacao { get; private set; }
        public string Tipo { get; private set; } = null!;

        public Usuario() { }

        public Usuario(string nome, string email, string senhaHash, string tipo = "Cliente")
        {
            if (string.IsNullOrWhiteSpace(nome)) throw new ArgumentException("Nome é obrigatório.");
            if (string.IsNullOrWhiteSpace(email)) throw new ArgumentException("E-mail é obrigatório.");

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
            DataAtualizacao = DateTime.UtcNow;
        }
    }
}