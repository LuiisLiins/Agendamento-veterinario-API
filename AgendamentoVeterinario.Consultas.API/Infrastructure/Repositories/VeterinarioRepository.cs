using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AgendamentoVeterinario.Consultas.API.Domain.Entities;
using AgendamentoVeterinario.Consultas.API.Domain.Repositories;
using DataApplication.Context;
using DataApplication.Models;
using Microsoft.EntityFrameworkCore;

namespace AgendamentoVeterinario.Consultas.API.Infrastructure.Repositories
{
    public class VeterinarioRepository : IVeterinarioRepository
    {
        private readonly AgendamentoVeterinarioContext _context;

        public VeterinarioRepository(AgendamentoVeterinarioContext context)
        {
            _context = context;
        }

        public async Task<Veterinario> AddAsync(Veterinario veterinario)
        {
            var model = new VeterinarioModel
            {
                Nome = veterinario.Nome,
                CRMV = veterinario.CRMV,
                Email = veterinario.Email,
                Telefone = veterinario.Telefone,
                Especialidade = veterinario.Especialidade,
                DataCriacao = veterinario.DataCriacao,
                Ativo = veterinario.Ativo
            };

            await _context.Veterinarios.AddAsync(model);

            typeof(Veterinario).GetProperty("Id")?.SetValue(veterinario, model.Id);
            return veterinario;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var model = await _context.Veterinarios.FirstOrDefaultAsync(x => x.Id == id);
            if (model is null)
                return false;

            _context.Veterinarios.Remove(model);
            return true;
        }

        public async Task<IEnumerable<Veterinario>> GetAllAsync()
        {
            var models = await _context.Veterinarios.ToListAsync();
            var list = new List<Veterinario>();

            foreach (var m in models)
            {
                list.Add(MapToEntity(m));
            }

            return list;
        }

        public async Task<Veterinario?> GetByIdAsync(int id)
        {
            var m = await _context.Veterinarios.FirstOrDefaultAsync(x => x.Id == id);
            if (m is null)
                return null;

            return MapToEntity(m);
        }

        public async Task<Veterinario?> UpdateAsync(int id, Veterinario veterinario)
        {
            var existing = await _context.Veterinarios.FirstOrDefaultAsync(x => x.Id == id);
            if (existing is null)
                return null;

            existing.Nome = veterinario.Nome;
            existing.CRMV = veterinario.CRMV;
            existing.Email = veterinario.Email;
            existing.Telefone = veterinario.Telefone;
            existing.Especialidade = veterinario.Especialidade;
            existing.Ativo = veterinario.Ativo;
            existing.DataAtualizacao = veterinario.DataAtualizacao;

            return veterinario;
        }

        private Veterinario MapToEntity(VeterinarioModel m)
        {
            var veterinario = (Veterinario)Activator.CreateInstance(typeof(Veterinario), true)!;
            typeof(Veterinario).GetProperty("Id")?.SetValue(veterinario, m.Id);
            typeof(Veterinario).GetProperty("Nome")?.SetValue(veterinario, m.Nome);
            typeof(Veterinario).GetProperty("CRMV")?.SetValue(veterinario, m.CRMV);
            typeof(Veterinario).GetProperty("Email")?.SetValue(veterinario, m.Email);
            typeof(Veterinario).GetProperty("Telefone")?.SetValue(veterinario, m.Telefone);
            typeof(Veterinario).GetProperty("Especialidade")?.SetValue(veterinario, m.Especialidade);
            typeof(Veterinario).GetProperty("DataCriacao")?.SetValue(veterinario, m.DataCriacao);
            typeof(Veterinario).GetProperty("DataAtualizacao")?.SetValue(veterinario, m.DataAtualizacao);
            typeof(Veterinario).GetProperty("Ativo")?.SetValue(veterinario, m.Ativo);
            return veterinario;
        }
    }
}