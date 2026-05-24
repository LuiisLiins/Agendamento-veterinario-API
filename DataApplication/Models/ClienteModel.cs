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
        public DateTime DataCriacao { get; set; } = DateTime.UtcNow;
        public DateTime? DataAtualizacao { get; set; }
        public bool Ativo { get; set; } = true;
        public Guid UsuarioId { get; set; }

        public ClienteModel() { }

        public ClienteModel(string cpf, string telefone, string endereco, string cidade, string estado, string cep, Guid usuarioId)
        {
            if (string.IsNullOrWhiteSpace(cpf)) throw new ArgumentException("CPF é obrigatório.");

            CPF = cpf;
            Telefone = telefone;
            Endereco = endereco;
            Cidade = cidade;
            Estado = estado;
            CEP = cep;
            UsuarioId = usuarioId;
            DataCriacao = DateTime.UtcNow;
            Ativo = true;
        }
    }
}