namespace AgendamentoVeterinario.Cadastro.API.Application.DTOs
{
    public class UsuarioDto
    {
        public string Nome { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string SenhaHash { get; set; } = null!;
    }
}
