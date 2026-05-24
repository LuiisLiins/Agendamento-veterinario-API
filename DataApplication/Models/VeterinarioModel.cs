using System;
using System.ComponentModel.DataAnnotations;

namespace DataApplication.Models
{
    public class VeterinarioModel
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; } = null!;
        public string CRMV { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Telefone { get; set; } = null!;
        public string Especialidade { get; set; } = null!;
        public DateTime DataCriacao { get; set; } = DateTime.UtcNow;
        public DateTime? DataAtualizacao { get; set; }
        public bool Ativo { get; set; } = true;

        public VeterinarioModel() { }

        public VeterinarioModel(string nome, string crmv, string email, string telefone, string especialidade)
        {
            Nome = nome;
            CRMV = crmv;
            Email = email;
            Telefone = telefone;
            Especialidade = especialidade;
            DataCriacao = DateTime.UtcNow;
            Ativo = true;
        }
    }
}