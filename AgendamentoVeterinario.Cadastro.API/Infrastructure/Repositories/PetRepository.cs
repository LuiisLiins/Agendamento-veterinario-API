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
            var model = new PetModel
            {
                ClienteId = pet.ClienteId,
                Nome = pet.Nome,
                Especie = pet.Especie,
                Raca = pet.Raca,
                Peso = pet.Peso,
                DataNascimento = pet.DataNascimento,
                Cor = pet.Cor,
                Sexo = pet.Sexo,
                NumeroMicrochip = pet.NumeroMicrochip,
                DataCriacao = pet.DataCriacao,
                Ativo = pet.Ativo
            };

            await _context.Pets.AddAsync(model);

            typeof(Pet).GetProperty("Id")?.SetValue(pet, model.Id);
            return pet;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var model = await _context.Pets.FirstOrDefaultAsync(x => x.Id == id);
            if (model is null)
                return false;

            _context.Pets.Remove(model);
            return true;
        }

        public async Task<IEnumerable<Pet>> GetAllAsync()
        {
            var models = await _context.Pets.ToListAsync();
            var list = new List<Pet>();

            foreach (var m in models)
            {
                list.Add(MapToEntity(m));
            }

            return list;
        }

        public async Task<Pet?> GetByIdAsync(int id)
        {
            var m = await _context.Pets.FirstOrDefaultAsync(x => x.Id == id);
            if (m is null)
                return null;

            return MapToEntity(m);
        }

        public async Task<IEnumerable<Pet>> GetByClienteIdAsync(int clienteId)
        {
            var models = await _context.Pets.Where(x => x.ClienteId == clienteId).ToListAsync();
            var list = new List<Pet>();

            foreach (var m in models)
            {
                list.Add(MapToEntity(m));
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
            existing.DataAtualizacao = pet.DataAtualizacao;

            return pet;
        }

        private Pet MapToEntity(PetModel m)
        {
            var pet = (Pet)Activator.CreateInstance(typeof(Pet), true)!;
            typeof(Pet).GetProperty("Id")?.SetValue(pet, m.Id);
            typeof(Pet).GetProperty("ClienteId")?.SetValue(pet, m.ClienteId);
            typeof(Pet).GetProperty("Nome")?.SetValue(pet, m.Nome);
            typeof(Pet).GetProperty("Especie")?.SetValue(pet, m.Especie);
            typeof(Pet).GetProperty("Raca")?.SetValue(pet, m.Raca);
            typeof(Pet).GetProperty("Peso")?.SetValue(pet, m.Peso);
            typeof(Pet).GetProperty("DataNascimento")?.SetValue(pet, m.DataNascimento);
            typeof(Pet).GetProperty("Cor")?.SetValue(pet, m.Cor);
            typeof(Pet).GetProperty("Sexo")?.SetValue(pet, m.Sexo);
            typeof(Pet).GetProperty("NumeroMicrochip")?.SetValue(pet, m.NumeroMicrochip);
            typeof(Pet).GetProperty("DataCriacao")?.SetValue(pet, m.DataCriacao);
            typeof(Pet).GetProperty("DataAtualizacao")?.SetValue(pet, m.DataAtualizacao);
            typeof(Pet).GetProperty("Ativo")?.SetValue(pet, m.Ativo);
            return pet;
        }
    }
}