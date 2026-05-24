using System;
using System.Collections.Generic;

namespace AgendamentoVeterinario.Consultas.API.Domain.Entities
{
    public class Veterinario
    {
        public int Id { get; private set; }
        public string Nome { get; private set; } = null!;
        public string CRMV { get; private set; } = null!;
        public string Email { get; private set; } = null!;
        public string Telefone { get; private set; } = null!;
        public string Especialidade { get; private set; } = null!;
        public DateTime DataCriacao { get; private set; } = DateTime.UtcNow;
        public DateTime? DataAtualizacao { get; private set; }
        public bool Ativo { get; private set; } = true;

        public virtual ICollection<Agendamento> Agendamentos { get; private set; } = new List<Agendamento>();

        protected Veterinario() { }

        public Veterinario(string nome, string crmv, string email, string telefone, string especialidade)
        {
            if (string.IsNullOrWhiteSpace(crmv)) throw new ArgumentException("O CRMV do veterinario e obrigatorio.");

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