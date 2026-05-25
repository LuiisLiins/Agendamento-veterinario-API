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
            var model = new AgendamentoModel
            {
                ClienteId = agendamento.ClienteId,
                PetId = agendamento.PetId,
                VeterinarioId = agendamento.VeterinarioId,
                DataHoraAgendamento = agendamento.DataHoraAgendamento,
                DataHoraFim = agendamento.DataHoraFim,
                TipoServico = agendamento.TipoServico,
                Valor = agendamento.Valor,
                Descricao = agendamento.Descricao,
                Observacoes = agendamento.Observacoes,
                DataCriacao = agendamento.DataCriacao,
                Ativo = agendamento.Ativo,
                StatusAgendamento = agendamento.StatusAgendamento
            };

            await _context.Agendamentos.AddAsync(model);

            typeof(Agendamento).GetProperty("Id")?.SetValue(agendamento, model.Id);
            return agendamento;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var model = await _context.Agendamentos.FirstOrDefaultAsync(x => x.Id == id);
            if (model is null)
                return false;

            _context.Agendamentos.Remove(model);
            return true;
        }

        public async Task<IEnumerable<Agendamento>> GetAllAsync()
        {
            var models = await _context.Agendamentos.ToListAsync();
            var list = new List<Agendamento>();

            foreach (var m in models)
            {
                list.Add(MapToEntity(m));
            }

            return list;
        }

        public async Task<IEnumerable<Agendamento>> GetByClienteIdAsync(int clienteId)
        {
            var models = await _context.Agendamentos.Where(x => x.ClienteId == clienteId).ToListAsync();
            var list = new List<Agendamento>();

            foreach (var m in models)
            {
                list.Add(MapToEntity(m));
            }

            return list;
        }

        public async Task<IEnumerable<Agendamento>> GetByVeterinarioIdAsync(int veterinarioId)
        {
            var models = await _context.Agendamentos.Where(x => x.VeterinarioId == veterinarioId).ToListAsync();
            var list = new List<Agendamento>();

            foreach (var m in models)
            {
                list.Add(MapToEntity(m));
            }

            return list;
        }

        public async Task<Agendamento?> GetByIdAsync(int id)
        {
            var m = await _context.Agendamentos.FirstOrDefaultAsync(x => x.Id == id);
            if (m is null)
                return null;

            return MapToEntity(m);
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
            existing.DataAtualizacao = agendamento.DataAtualizacao;

            return agendamento;
        }

        private Agendamento MapToEntity(AgendamentoModel m)
        {
            var agendamento = (Agendamento)Activator.CreateInstance(typeof(Agendamento), true)!;
            typeof(Agendamento).GetProperty("Id")?.SetValue(agendamento, m.Id);
            typeof(Agendamento).GetProperty("ClienteId")?.SetValue(agendamento, m.ClienteId);
            typeof(Agendamento).GetProperty("PetId")?.SetValue(agendamento, m.PetId);
            typeof(Agendamento).GetProperty("VeterinarioId")?.SetValue(agendamento, m.VeterinarioId);
            typeof(Agendamento).GetProperty("DataHoraAgendamento")?.SetValue(agendamento, m.DataHoraAgendamento);
            typeof(Agendamento).GetProperty("DataHoraFim")?.SetValue(agendamento, m.DataHoraFim);
            typeof(Agendamento).GetProperty("TipoServico")?.SetValue(agendamento, m.TipoServico);
            typeof(Agendamento).GetProperty("Valor")?.SetValue(agendamento, m.Valor);
            typeof(Agendamento).GetProperty("Descricao")?.SetValue(agendamento, m.Descricao);
            typeof(Agendamento).GetProperty("Observacoes")?.SetValue(agendamento, m.Observacoes);
            typeof(Agendamento).GetProperty("DataCriacao")?.SetValue(agendamento, m.DataCriacao);
            typeof(Agendamento).GetProperty("DataAtualizacao")?.SetValue(agendamento, m.DataAtualizacao);
            typeof(Agendamento).GetProperty("Ativo")?.SetValue(agendamento, m.Ativo);
            typeof(Agendamento).GetProperty("StatusAgendamento")?.SetValue(agendamento, m.StatusAgendamento);
            return agendamento;
        }
    }
}