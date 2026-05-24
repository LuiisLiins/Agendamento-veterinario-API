using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DataApplication.Models
{
    public class Clientes
    {
        public int Id { get; private set; }
        public string CPF { get; private set; } = null!;
        public string Telefone { get; private set; } = null!;
        public string Endereco { get; private set; } = null!;
        public string Cidade { get; private set; } = null!;
        public string Estado { get; private set; } = null!;
        public string CEP { get; private set; } = null!;
        public DateTime DataCriacao { get; private set; } = DateTime.UtcNow;
        public DateTime? DataAtualizacao { get; private set; }
        public bool Ativo { get; private set; } = true;
        public Guid UsuarioId { get; private set; }

        public Clientes() { }

        public Clientes(string cpf, string telefone, string endereco, string cidade, string estado, string cep, Guid usuarioId)
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

        public void Desativar()
        {
            Ativo = false;
            DataAtualizacao = DateTime.UtcNow;
        }
    }
}