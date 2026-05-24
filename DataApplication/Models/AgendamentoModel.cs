using System;
using System.ComponentModel.DataAnnotations;

namespace DataApplication.Models
{
    public class AgendamentoModel
    {
        [Key]
        public int Id { get; set; }
        public int ClienteId { get; set; }
        public int PetId { get; set; }
        public int VeterinarioId { get; set; }
        public DateTime DataHoraAgendamento { get; set; }
        public DateTime? DataHoraFim { get; set; }
        public string TipoServico { get; set; } = null!;
        public string Descricao { get; set; } = null!;
        public decimal Valor { get; set; }
        public string Observacoes { get; set; } = null!;
        public DateTime DataCriacao { get; set; } = DateTime.UtcNow;
        public DateTime? DataAtualizacao { get; set; }
        public bool Ativo { get; set; } = true;
        public string StatusAgendamento { get; set; } = "Agendado";

        public AgendamentoModel() { }

        public AgendamentoModel(int clienteId, int petId, int veterinarioId, DateTime dataHora, string tipoServico, decimal valor, string descricao, string observacoes)
        {
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
    }
}