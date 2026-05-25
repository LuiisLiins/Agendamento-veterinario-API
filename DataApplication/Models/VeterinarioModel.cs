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
        public DateTime DataCriacao { get; set; }
        public DateTime? DataAtualizacao { get; set; }
        public bool Ativo { get; set; }
    }
}