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
        public DateTime DataCriacao { get; set; }
        public DateTime? DataAtualizacao { get; set; }
        public bool Ativo { get; set; }
        public string StatusAgendamento { get; set; } = null!;
    }
}