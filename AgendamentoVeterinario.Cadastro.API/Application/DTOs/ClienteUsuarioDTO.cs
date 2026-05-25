namespace AgendamentoVeterinario.Cadastro.API.Application.DTOs
{
    public class ClienteUsuarioDto
    {
        // Dados que vão para a tabela de Usuario
        public string Nome { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Senha { get; set; } = null!;

        // Dados que vão para a tabela de Cliente
        public string CPF { get; set; } = null!;
        public string Telefone { get; set; } = null!;
        public string Endereco { get; set; } = null!;
        public string Cidade { get; set; } = null!;
        public string Estado { get; set; } = null!;
        public string CEP { get; set; } = null!;
    }
}