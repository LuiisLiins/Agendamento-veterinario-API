namespace AgendamentoVeterinario.Cadastro.API.Application.DTOs
{
    public class PetDto
    {
        public int ClienteId { get; set; }
        public string Nome { get; set; } = null!;
        public string Especie { get; set; } = null!;
        public string Raca { get; set; } = null!;
        public decimal Peso { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Cor { get; set; } = null!;
        public string Sexo { get; set; } = null!;
        public string NumeroMicrochip { get; set; } = null!;
    }
}
