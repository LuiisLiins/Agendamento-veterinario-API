namespace Agendamento_Veterinario___Back.Domain.Entities
{
    public class Veterinario
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public string CRMV { get; set; }

        public string Email { get; set; }

        public string Telefone { get; set; }

        public string Especialidade { get; set; }

        public DateTime DataCriacao { get; set; } = DateTime.UtcNow;

        public DateTime? DataAtualizacao { get; set; }

        public bool Ativo { get; set; } = true;

     
        public virtual ICollection<Agendamento> Agendamentos { get; set; } = new List<Agendamento>();


     
        public Veterinario(string nome, string crmv, string email, string telefone, string especialidade)
        {
            Nome = nome;
            CRMV = crmv;
            Email = email;
            Telefone = telefone;
            Especialidade = especialidade;
        }
    }
}

