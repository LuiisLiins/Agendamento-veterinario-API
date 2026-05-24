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
    public class AgendamentoRepository : IAgendamentoRepository
    {
        private readonly AgendamentoVeterinarioContext _context;

        public AgendamentoRepository(AgendamentoVeterinarioContext context)
        {
            _context = context;
        }

        public async Task<Agendamento> AddAsync(Agendamento agendamento)
        {
            var model = new AgendamentoModel(
                agendamento.ClienteId,
                agendamento.PetId,
                agendamento.VeterinarioId,
                agendamento.DataHoraAgendamento,
                agendamento.TipoServico,
                agendamento.Valor,
                agendamento.Descricao,
                agendamento.Observacoes
            );

            await _context.Agendamentos.AddAsync(model);
            await _context.SaveChangesAsync();

            typeof(Agendamento).GetProperty("Id")?.SetValue(agendamento, model.Id);
            return agendamento;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var model = await _context.Agendamentos.FirstOrDefaultAsync(x => x.Id == id);
            if (model is null)
                return false;

            _context.Agendamentos.Remove(model);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Agendamento>> GetAllAsync()
        {
            var models = await _context.Agendamentos.ToListAsync();
            var list = new List<Agendamento>();

            foreach (var m in models)
            {
                var agendamento = new Agendamento(m.ClienteId, m.PetId, m.VeterinarioId, m.DataHoraAgendamento, m.TipoServico, m.Valor, m.Descricao, m.Observacoes);
                typeof(Agendamento).GetProperty("Id")?.SetValue(agendamento, m.Id);
                typeof(Agendamento).GetProperty("StatusAgendamento")?.SetValue(agendamento, m.StatusAgendamento);
                typeof(Agendamento).GetProperty("Ativo")?.SetValue(agendamento, m.Ativo);
                list.Add(agendamento);
            }

            return list;
        }

        public async Task<IEnumerable<Agendamento>> GetByClienteIdAsync(int clienteId)
        {
            var models = await _context.Agendamentos.Where(x => x.ClienteId == clienteId).ToListAsync();
            var list = new List<Agendamento>();

            foreach (var m in models)
            {
                var agendamento = new Agendamento(m.ClienteId, m.PetId, m.VeterinarioId, m.DataHoraAgendamento, m.TipoServico, m.Valor, m.Descricao, m.Observacoes);
                typeof(Agendamento).GetProperty("Id")?.SetValue(agendamento, m.Id);
                typeof(Agendamento).GetProperty("StatusAgendamento")?.SetValue(agendamento, m.StatusAgendamento);
                typeof(Agendamento).GetProperty("Ativo")?.SetValue(agendamento, m.Ativo);
                list.Add(agendamento);
            }

            return list;
        }

        public async Task<IEnumerable<Agendamento>> GetByVeterinarioIdAsync(int veterinarioId)
        {
            var models = await _context.Agendamentos.Where(x => x.VeterinarioId == veterinarioId).ToListAsync();
            var list = new List<Agendamento>();

            foreach (var m in models)
            {
                var agendamento = new Agendamento(m.ClienteId, m.PetId, m.VeterinarioId, m.DataHoraAgendamento, m.TipoServico, m.Valor, m.Descricao, m.Observacoes);
                typeof(Agendamento).GetProperty("Id")?.SetValue(agendamento, m.Id);
                typeof(Agendamento).GetProperty("StatusAgendamento")?.SetValue(agendamento, m.StatusAgendamento);
                typeof(Agendamento).GetProperty("Ativo")?.SetValue(agendamento, m.Ativo);
                list.Add(agendamento);
            }

            return list;
        }

        public async Task<Agendamento?> GetByIdAsync(int id)
        {
            var m = await _context.Agendamentos.FirstOrDefaultAsync(x => x.Id == id);
            if (m is null)
                return null;

            var agendamento = new Agendamento(m.ClienteId, m.PetId, m.VeterinarioId, m.DataHoraAgendamento, m.TipoServico, m.Valor, m.Descricao, m.Observacoes);
            typeof(Agendamento).GetProperty("Id")?.SetValue(agendamento, m.Id);
            typeof(Agendamento).GetProperty("StatusAgendamento")?.SetValue(agendamento, m.StatusAgendamento);
            typeof(Agendamento).GetProperty("Ativo")?.SetValue(agendamento, m.Ativo);

            return agendamento;
        }

        public async Task<Agendamento?> UpdateAsync(int id, Agendamento agendamento)
        {
            var existing = await _context.Agendamentos.FirstOrDefaultAsync(x => x.Id == id);
            if (existing is null)
                return null;

            existing.ClienteId = agendamento.ClienteId;
            existing.PetId = agendamento.PetId;
            existing.VeterinarioId = agendamento.VeterinarioId;
            existing.DataHoraAgendamento = agendamento.DataHoraAgendamento;
            existing.DataHoraFim = agendamento.DataHoraFim;
            existing.TipoServico = agendamento.TipoServico;
            existing.Descricao = agendamento.Descricao;
            existing.Valor = agendamento.Valor;
            existing.Observacoes = agendamento.Observacoes;
            existing.StatusAgendamento = agendamento.StatusAgendamento;
            existing.Ativo = agendamento.Ativo;
            existing.DataAtualizacao = DateTime.UtcNow;

            await _context.SaveChangesAsync();
            return agendamento;
        }
    }
}