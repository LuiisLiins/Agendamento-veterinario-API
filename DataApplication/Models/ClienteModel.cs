using System;
using System.ComponentModel.DataAnnotations;

namespace DataApplication.Models
{
    public class ClienteModel
    {
        [Key]
        public int Id { get; set; }
        public string CPF { get; set; } = null!;
        public string Telefone { get; set; } = null!;
        public string Endereco { get; set; } = null!;
        public string Cidade { get; set; } = null!;
        public string Estado { get; set; } = null!;
        public string CEP { get; set; } = null!;
        public DateTime DataCriacao { get; set; }
        public DateTime? DataAtualizacao { get; set; }
        public bool Ativo { get; set; }
        public Guid UsuarioId { get; set; }
    }
}