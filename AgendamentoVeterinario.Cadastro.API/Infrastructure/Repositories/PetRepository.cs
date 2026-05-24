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
    public class PetRepository : IPetRepository
    {
        private readonly AgendamentoVeterinarioContext _context;

        public PetRepository(AgendamentoVeterinarioContext context)
        {
            _context = context;
        }

        public async Task<Pet> AddAsync(Pet pet)
        {
            var model = new PetModel(
                pet.ClienteId,
                pet.Nome,
                pet.Especie,
                pet.Raca,
                pet.Peso,
                pet.DataNascimento,
                pet.Cor,
                pet.Sexo,
                pet.NumeroMicrochip
            );

            await _context.Pets.AddAsync(model);
            await _context.SaveChangesAsync();

            typeof(Pet).GetProperty("Id")?.SetValue(pet, model.Id);
            return pet;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var model = await _context.Pets.FirstOrDefaultAsync(x => x.Id == id);
            if (model is null)
                return false;

            _context.Pets.Remove(model);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Pet>> GetAllAsync()
        {
            var models = await _context.Pets.ToListAsync();
            var list = new List<Pet>();

            foreach (var m in models)
            {
                var pet = new Pet(m.ClienteId, m.Nome, m.Especie, m.Raca, m.Peso, m.DataNascimento, m.Cor, m.Sexo, m.NumeroMicrochip);
                typeof(Pet).GetProperty("Id")?.SetValue(pet, m.Id);
                typeof(Pet).GetProperty("Ativo")?.SetValue(pet, m.Ativo);
                list.Add(pet);
            }

            return list;
        }

        public async Task<Pet?> GetByIdAsync(int id)
        {
            var m = await _context.Pets.FirstOrDefaultAsync(x => x.Id == id);
            if (m is null)
                return null;

            var pet = new Pet(m.ClienteId, m.Nome, m.Especie, m.Raca, m.Peso, m.DataNascimento, m.Cor, m.Sexo, m.NumeroMicrochip);
            typeof(Pet).GetProperty("Id")?.SetValue(pet, m.Id);
            typeof(Pet).GetProperty("Ativo")?.SetValue(pet, m.Ativo);

            return pet;
        }

        public async Task<IEnumerable<Pet>> GetByClienteIdAsync(int clienteId)
        {
            var models = await _context.Pets.Where(x => x.ClienteId == clienteId).ToListAsync();
            var list = new List<Pet>();

            foreach (var m in models)
            {
                var pet = new Pet(m.ClienteId, m.Nome, m.Especie, m.Raca, m.Peso, m.DataNascimento, m.Cor, m.Sexo, m.NumeroMicrochip);
                typeof(Pet).GetProperty("Id")?.SetValue(pet, m.Id);
                typeof(Pet).GetProperty("Ativo")?.SetValue(pet, m.Ativo);
                list.Add(pet);
            }

            return list;
        }

        public async Task<bool> ExisteConsultaFuturaParaOPetAsync(int petId)
        {
            return await _context.Agendamentos.AnyAsync(x => x.PetId == petId && x.DataHoraAgendamento > DateTime.UtcNow);
        }

        public async Task<Pet?> UpdateAsync(int id, Pet pet)
        {
            var existing = await _context.Pets.FirstOrDefaultAsync(x => x.Id == id);
            if (existing is null)
                return null;

            existing.Nome = pet.Nome;
            existing.Especie = pet.Especie;
            existing.Raca = pet.Raca;
            existing.Peso = pet.Peso;
            existing.DataNascimento = pet.DataNascimento;
            existing.Cor = pet.Cor;
            existing.Sexo = pet.Sexo;
            existing.NumeroMicrochip = pet.NumeroMicrochip;
            existing.Ativo = pet.Ativo;
            existing.DataAtualizacao = DateTime.UtcNow;

            await _context.SaveChangesAsync();
            return pet;
        }
    }
}