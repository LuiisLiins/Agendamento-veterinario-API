namespace Agendamento_Veterinario___Back.Domain.Entities
{
    public class Clientes
    {

        public int Id { get; set; }

        public string Nome { get; set; } = null!;

        public string CPF { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string Telefone { get; set; } = null!;

        public string Endereco { get; set; } = null!;
        public string Cidade { get; set; } = null!;

        public string Estado { get; set; } = null!;

        public string CEP { get; set; } = null!;

        public DateTime DataCriacao { get; set; } = DateTime.UtcNow;

        public DateTime? DataAtualizacao { get; set; }

        public bool Ativo { get; set; } = true;

        public virtual ICollection<Pet> Animais { get; set; } = new List<Pet>();

        public virtual ICollection<Agendamento> Agendamentos { get; set; } = new List<Agendamento>();

       

        public Clientes(string nome, string cpf, string email, string telefone, string endereco)
        {
            Nome = nome;
            CPF = cpf;
            Email = email;
            Telefone = telefone;
            Endereco = endereco;
        }
    }
}

