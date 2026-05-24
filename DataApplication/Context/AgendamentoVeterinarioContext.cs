using Microsoft.EntityFrameworkCore;
using DataApplication.Models;

namespace DataApplication.Context
{
    public class AgendamentoVeterinarioContext : DbContext
    {
        public AgendamentoVeterinarioContext(DbContextOptions<AgendamentoVeterinarioContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AgendamentoModel> Agendamentos { get; set; }
        public virtual DbSet<VeterinarioModel> Veterinarios { get; set; }
        public virtual DbSet<UsuarioModel> Usuarios { get; set; }
        public virtual DbSet<ClienteModel> Clientes { get; set; }
        public virtual DbSet<PetModel> Pets { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AgendamentoModel>().ToTable("Agendamentos");
            modelBuilder.Entity<VeterinarioModel>().ToTable("Veterinarios");
            modelBuilder.Entity<UsuarioModel>().ToTable("Usuarios");
            modelBuilder.Entity<ClienteModel>().ToTable("Clientes");
            modelBuilder.Entity<PetModel>().ToTable("Pets");

            base.OnModelCreating(modelBuilder);
        }
    }
}