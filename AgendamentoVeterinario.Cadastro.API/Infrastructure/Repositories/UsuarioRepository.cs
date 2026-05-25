using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AgendamentoVeterinario.Cadastro.API.Domain.Entities;
using AgendamentoVeterinario.Cadastro.API.Domain.Repositories;
using DataApplication.Context;
using DataApplication.Models;
using Microsoft.EntityFrameworkCore;

namespace AgendamentoVeterinario.Cadastro.API.Infrastructure.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly AgendamentoVeterinarioContext _context;

        public UsuarioRepository(AgendamentoVeterinarioContext context)
        {
            _context = context;
        }

        public async Task<Usuario> AddAsync(Usuario usuario)
        {
            var model = new UsuarioModel
            {
                Id = usuario.Id,
                Nome = usuario.Nome,
                Email = usuario.Email,
                SenhaHash = usuario.SenhaHash,
                Ativo = usuario.Ativo,
                DataCriacao = usuario.DataCriacao
            };

            await _context.Usuarios.AddAsync(model);

            return usuario;
        }

        public async Task<IEnumerable<Usuario>> GetAllAsync()
        {
            var models = await _context.Usuarios.ToListAsync();
            var list = new List<Usuario>();

            foreach (var m in models)
            {
                list.Add(MapToEntity(m));
            }

            return list;
        }

        public async Task<Usuario?> GetByEmailAsync(string email)
        {
            var m = await _context.Usuarios.FirstOrDefaultAsync(x => x.Email == email);
            if (m is null)
                return null;

            return MapToEntity(m);
        }

        public async Task<Usuario?> GetByIdAsync(Guid id)
        {
            var m = await _context.Usuarios.FirstOrDefaultAsync(x => x.Id == id);
            if (m is null)
                return null;

            return MapToEntity(m);
        }

        public async Task<Usuario?> UpdateAsync(Guid id, Usuario usuario)
        {
            var existing = await _context.Usuarios.FirstOrDefaultAsync(x => x.Id == id);
            if (existing is null)
                return null;

            existing.Nome = usuario.Nome;
            existing.Email = usuario.Email;
            existing.SenhaHash = usuario.SenhaHash;
            existing.Ativo = usuario.Ativo;

            return usuario;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var model = await _context.Usuarios.FirstOrDefaultAsync(x => x.Id == id);
            if (model is null) return false;

            _context.Usuarios.Remove(model);
            return true;
        }

        private Usuario MapToEntity(UsuarioModel m)
        {
            var usuario = (Usuario)Activator.CreateInstance(typeof(Usuario), true)!;
            typeof(Usuario).GetProperty("Id")?.SetValue(usuario, m.Id);
            typeof(Usuario).GetProperty("Nome")?.SetValue(usuario, m.Nome);
            typeof(Usuario).GetProperty("Email")?.SetValue(usuario, m.Email);
            typeof(Usuario).GetProperty("SenhaHash")?.SetValue(usuario, m.SenhaHash);
            typeof(Usuario).GetProperty("Ativo")?.SetValue(usuario, m.Ativo);
            typeof(Usuario).GetProperty("DataCriacao")?.SetValue(usuario, m.DataCriacao);
            return usuario;
        }
    }
}