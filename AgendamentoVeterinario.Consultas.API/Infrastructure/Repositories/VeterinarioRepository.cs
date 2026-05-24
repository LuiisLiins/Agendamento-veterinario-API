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
            var model = new VeterinarioModel(
                veterinario.Nome,
                veterinario.CRMV,
                veterinario.Email,
                veterinario.Telefone,
                veterinario.Especialidade
            );

            await _context.Veterinarios.AddAsync(model);
            await _context.SaveChangesAsync();

            typeof(Veterinario).GetProperty("Id")?.SetValue(veterinario, model.Id);
            return veterinario;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var model = await _context.Veterinarios.FirstOrDefaultAsync(x => x.Id == id);
            if (model is null)
                return false;

            _context.Veterinarios.Remove(model);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Veterinario>> GetAllAsync()
        {
            var models = await _context.Veterinarios.ToListAsync();
            var list = new List<Veterinario>();

            foreach (var m in models)
            {
                var veterinario = new Veterinario(m.Nome, m.CRMV, m.Email, m.Telefone, m.Especialidade);
                typeof(Veterinario).GetProperty("Id")?.SetValue(veterinario, m.Id);
                typeof(Veterinario).GetProperty("Ativo")?.SetValue(veterinario, m.Ativo);
                list.Add(veterinario);
            }

            return list;
        }

        public async Task<Veterinario?> GetByIdAsync(int id)
        {
            var m = await _context.Veterinarios.FirstOrDefaultAsync(x => x.Id == id);
            if (m is null)
                return null;

            var veterinario = new Veterinario(m.Nome, m.CRMV, m.Email, m.Telefone, m.Especialidade);
            typeof(Veterinario).GetProperty("Id")?.SetValue(veterinario, m.Id);
            typeof(Veterinario).GetProperty("Ativo")?.SetValue(veterinario, m.Ativo);

            return veterinario;
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
            typeof(VeterinarioModel).GetProperty("DataAtualizacao")?.SetValue(existing, DateTime.UtcNow);

            await _context.SaveChangesAsync();
            return veterinario;
        }
    }
}