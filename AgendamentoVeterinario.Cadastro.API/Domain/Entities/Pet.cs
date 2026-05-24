using System;
using System.ComponentModel.DataAnnotations;

namespace AgendamentoVeterinario.Cadastro.API.Domain.Entities
{
    public class Pet
    {
        public int Id { get; private set; }
        public int ClienteId { get; private set; }
        public string Nome { get; private set; } = null!;
        public string Especie { get; private set; } = null!;
        public string Raca { get; private set; } = null!;
        public decimal Peso { get; private set; }
        public DateTime DataNascimento { get; private set; }
        public string Cor { get; private set; } = null!;
        public string Sexo { get; private set; } = null!;
        public string NumeroMicrochip { get; private set; } = null!;
        public DateTime DataCriacao { get; private set; } = DateTime.UtcNow;
        public DateTime? DataAtualizacao { get; private set; }
        public bool Ativo { get; private set; } = true;

        public Pet() { }

        public Pet(int clienteId, string nome, string especie, string raca, decimal peso, DateTime dataNascimento, string cor, string sexo, string numeroMicrochip)
        {
            if (string.IsNullOrWhiteSpace(nome)) throw new ArgumentException("O nome do pet é obrigatório.");
            if (dataNascimento > DateTime.UtcNow) throw new ArgumentException("A data de nascimento não pode ser no futuro.");

            ClienteId = clienteId;
            Nome = nome;
            Especie = especie;
            Raca = raca;
            Peso = peso;
            DataNascimento = dataNascimento;
            Cor = cor;
            Sexo = sexo;
            NumeroMicrochip = numeroMicrochip;
            DataCriacao = DateTime.UtcNow;
            Ativo = true;
        }

        public int GetIdadeEmAnos()
        {
            var hoje = DateTime.UtcNow;
            var idade = hoje.Year - DataNascimento.Year;

            if (DataNascimento.Date > hoje.AddYears(-idade))
                idade--;

            return idade;
        }

        public bool ValidarSePodeSerExcluido(bool possuiAgendamentosAtivosNoFuturo)
        {
            if (possuiAgendamentosAtivosNoFuturo)
            {
                return false;
            }

            return true;
        }

        public void Desativar()
        {
            Ativo = false;
            DataAtualizacao = DateTime.UtcNow;
        }
    }
}