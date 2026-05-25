namespace AgendamentoVeterinario.Cadastro.API.Application.DTOs
{
    public class UsuarioDto
    {
        // Dados que vão para a tabela de Usuario
        public string Nome { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Senha { get; set; } = null!;
    }
}