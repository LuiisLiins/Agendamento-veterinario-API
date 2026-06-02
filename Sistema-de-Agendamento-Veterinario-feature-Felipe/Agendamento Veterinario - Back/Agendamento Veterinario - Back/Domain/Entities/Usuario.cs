namespace Agendamento_Veterinario___Back.Domain.Entities
{
    public class Usuario
    {
        public Guid Id { get; set; }

        public string Nome { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string SenhaHash { get; set; } = null!;


        public bool Ativo { get; set; }

        public DateTime DataCriacao { get; set; }
    }
}
