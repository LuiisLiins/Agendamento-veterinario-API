using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AgendamentoVeterinario.Cadastro.API.Domain.Entities;
using AgendamentoVeterinario.Cadastro.API.Domain.Repositories;
using DataApplication.Context;
using DataApplication.Models;


namespace AgendamentoVeterinario.Cadastro.API.Infrastructure.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly AgendamentoVeterinarioContext _context;

        public ClienteRepository(AgendamentoVeterinarioContext context)
        {
            _context = context;
        }

        public async Task<Cliente> AddAsync(Cliente cliente)
        {
            var model = new ClienteModel
            {
                UsuarioId = cliente.UsuarioId,
                CPF = cliente.CPF,
                Telefone = cliente.Telefone,
                Endereco = cliente.Endereco,
                Cidade = cliente.Cidade,
                Estado = cliente.Estado,
                CEP = cliente.CEP
            };

            await _context.Clientes.AddAsync(model);
            await _context.SaveChangesAsync();

            typeof(Cliente).GetProperty("Id")?.SetValue(cliente, model.Id);
            return cliente;
        }

        public async Task<Cliente?> GetByCpfAsync(string cpf)
        {
            var m = await _context.Clientes.FirstOrDefaultAsync(x => x.CPF == cpf);
            if (m is null) return null;

            var cliente = (Cliente)Activator.CreateInstance(typeof(Cliente), true)!;
            typeof(Cliente).GetProperty("Id")?.SetValue(cliente, m.Id);
            typeof(Cliente).GetProperty("UsuarioId")?.SetValue(cliente, m.UsuarioId);
            typeof(Cliente).GetProperty("CPF")?.SetValue(cliente, m.CPF);
            typeof(Cliente).GetProperty("Telefone")?.SetValue(cliente, m.Telefone);
            typeof(Cliente).GetProperty("Endereco")?.SetValue(cliente, m.Endereco);
            typeof(Cliente).GetProperty("Cidade")?.SetValue(cliente, m.Cidade);
            typeof(Cliente).GetProperty("Estado")?.SetValue(cliente, m.Estado);
            typeof(Cliente).GetProperty("CEP")?.SetValue(cliente, m.CEP);

            return cliente;
        }

        public async Task<Cliente?> GetByIdAsync(int id)
        {
            var m = await _context.Clientes.FirstOrDefaultAsync(x => x.Id == id);
            if (m is null) return null;

            var cliente = (Cliente)Activator.CreateInstance(typeof(Cliente), true)!;
            typeof(Cliente).GetProperty("Id")?.SetValue(cliente, m.Id);
            typeof(Cliente).GetProperty("UsuarioId")?.SetValue(cliente, m.UsuarioId);
            typeof(Cliente).GetProperty("CPF")?.SetValue(cliente, m.CPF);
            typeof(Cliente).GetProperty("Telefone")?.SetValue(cliente, m.Telefone);
            typeof(Cliente).GetProperty("Endereco")?.SetValue(cliente, m.Endereco);
            typeof(Cliente).GetProperty("Cidade")?.SetValue(cliente, m.Cidade);
            typeof(Cliente).GetProperty("Estado")?.SetValue(cliente, m.Estado);
            typeof(Cliente).GetProperty("CEP")?.SetValue(cliente, m.CEP);

            return cliente;
        }

        public async Task<IEnumerable<Cliente>> GetAllAsync()
        {
            var models = await _context.Clientes.ToListAsync();
            var list = new List<Cliente>();

            foreach (var m in models)
            {
                var cliente = (Cliente)Activator.CreateInstance(typeof(Cliente), true)!;
                typeof(Cliente).GetProperty("Id")?.SetValue(cliente, m.Id);
                typeof(Cliente).GetProperty("UsuarioId")?.SetValue(cliente, m.UsuarioId);
                typeof(Cliente).GetProperty("CPF")?.SetValue(cliente, m.CPF);
                typeof(Cliente).GetProperty("Telefone")?.SetValue(cliente, m.Telefone);
                typeof(Cliente).GetProperty("Endereco")?.SetValue(cliente, m.Endereco);
                typeof(Cliente).GetProperty("Cidade")?.SetValue(cliente, m.Cidade);
                typeof(Cliente).GetProperty("Estado")?.SetValue(cliente, m.Estado);
                typeof(Cliente).GetProperty("CEP")?.SetValue(cliente, m.CEP);
                list.Add(cliente);
            }

            return list;
        }

        public async Task<Cliente?> UpdateAsync(int id, Cliente cliente)
        {
            var existing = await _context.Clientes.FirstOrDefaultAsync(x => x.Id == id);
            if (existing is null) return null;

            existing.Telefone = cliente.Telefone;
            existing.Endereco = cliente.Endereco;
            existing.Cidade = cliente.Cidade;
            existing.Estado = cliente.Estado;
            existing.CEP = cliente.CEP;

            await _context.SaveChangesAsync();
            return cliente;
        }
    }
}