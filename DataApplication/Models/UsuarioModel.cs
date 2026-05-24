using System;
using System.ComponentModel.DataAnnotations;

namespace DataApplication.Models
{
    public class UsuarioModel
    {
        [Key]
        public Guid Id { get; set; }
        public string Nome { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string SenhaHash { get; set; } = null!;
        public bool Ativo { get; set; }
        public DateTime DataCriacao { get; set; }

        public UsuarioModel() { }

        public UsuarioModel(string nome, string email, string senhaHash)
        {
            Id = Guid.NewGuid();
            Nome = nome;
            Email = email;
            SenhaHash = senhaHash;
            Ativo = true;
            DataCriacao = DateTime.UtcNow;
        }

        public void Desativar()
        {
            Ativo = false;
        }
    }
}