using System.Collections.Generic;
using Agendamento_Veterinario___Back.Domain.Entities;

namespace Agendamento_Veterinario___Back.Domain.Repositories
{
    public static class InMemoryDatabase
    {
        public static List<Clientes> Clientes { get; } = new List<Clientes>();
        public static List<Pet> Pets { get; } = new List<Pet>();
        public static List<Veterinario> Veterinarios { get; } = new List<Veterinario>();
        public static List<Agendamento> Agendamentos { get; } = new List<Agendamento>();
        public static List<Usuario> Usuarios { get; } = new List<Usuario>();
    }
}

