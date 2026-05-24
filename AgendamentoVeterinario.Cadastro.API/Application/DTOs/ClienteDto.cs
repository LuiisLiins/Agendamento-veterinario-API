namespace AgendamentoVeterinario.Cadastro.API.Application.DTOs
{
    public class ClienteDto
    {   
        public string CPF { get; set; } = null!;
        public string Telefone { get; set; } = null!;
        public string Endereco { get; set; } = null!;
        public string Cidade { get; set; } = null!;
        public string Estado { get; set; } = null!;
        public string CEP { get; set; } = null!;
    }
}
