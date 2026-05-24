using System;

namespace AgendamentoVeterinario.Consultas.API.Domain.Entities
{
    public class Agendamento
    {
        public int Id { get; private set; }
        public int ClienteId { get; private set; }
        public int PetId { get; private set; }
        public int VeterinarioId { get; private set; }
        public DateTime DataHoraAgendamento { get; private set; }
        public DateTime? DataHoraFim { get; private set; }
        public string TipoServico { get; private set; } = null!;
        public string Descricao { get; private set; } = null!;
        public decimal Valor { get; private set; }
        public string Observacoes { get; private set; } = null!;
        public DateTime DataCriacao { get; private set; } = DateTime.UtcNow;
        public DateTime? DataAtualizacao { get; private set; }
        public bool Ativo { get; private set; } = true;
        public string StatusAgendamento { get; private set; } = "Agendado";

        public virtual Veterinario Veterinario { get; private set; } = null!;

        // 🛠️ MUDANÇA AQUI: Alterado de protected para public para o System.Text.Json usar como fallback
        public Agendamento() { }

        public Agendamento(int clienteId, int petId, int veterinarioId, DateTime dataHora, string tipoServico, decimal valor, string descricao, string observacoes)
        {
            if (dataHora < DateTime.UtcNow) throw new ArgumentException("A data da consulta nao pode ser retroativa.");
            if (valor <= 0) throw new ArgumentException("O valor da consulta precisa ser maior que zero.");

            ClienteId = clienteId;
            PetId = petId;
            VeterinarioId = veterinarioId;
            DataHoraAgendamento = dataHora;
            DataHoraFim = dataHora.AddHours(1);
            TipoServico = tipoServico;
            Valor = valor;
            Descricao = descricao;
            Observacoes = observacoes;
            DataCriacao = DateTime.UtcNow;
            Ativo = true;
            StatusAgendamento = "Agendado";
        }

        public bool ValidarConflitoHorario(DateTime novaDataHora)
        {
            var fimConsultaExistente = DataHoraFim ?? DataHoraAgendamento.AddHours(1);
            var novoFimConsulta = novaDataHora.AddHours(1);

            return novaDataHora < fimConsultaExistente && novoFimConsulta > DataHoraAgendamento;
        }

        public void Cancelar()
        {
            StatusAgendamento = "Cancelado";
            Ativo = false;
            DataAtualizacao = DateTime.UtcNow;
        }
    }
}