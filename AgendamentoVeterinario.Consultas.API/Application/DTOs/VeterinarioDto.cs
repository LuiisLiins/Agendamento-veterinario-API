namespace AgendamentoVeterinario.Consultas.API.Application.DTOs
{
    public class VeterinarioDto
    {
        public string Nome { get; set; } = null!;
        public string CRMV { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Telefone { get; set; } = null!;
        public string Especialidade { get; set; } = null!;
    }
}
