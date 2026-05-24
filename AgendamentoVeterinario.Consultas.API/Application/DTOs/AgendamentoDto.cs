using System;

namespace AgendamentoVeterinario.Consultas.API.Application.DTO
{
    public class AgendamentoDto
    {
        public int ClienteId { get; set; }
        public int PetId { get; set; }
        public int VeterinarioId { get; set; }
        public DateTime DataHoraAgendamento { get; set; }
        public string TipoServico { get; set; } = null!;
        public string Descricao { get; set; } = null!;
        public decimal Valor { get; set; }
        public string Observacoes { get; set; } = null!;
    }
}