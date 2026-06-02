using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Agendamento_Veterinario___Back.Domain.Entities;
using Agendamento_Veterinario___Back.Domain.Repositories;

namespace Agendamento_Veterinario___Back.Repositories
{
    public class PetRepository : IPetRepository
    {
        public Task<Pet> AddAsync(Pet pet)
        {
            pet.Id = InMemoryDatabase.Pets.Count > 0
                ? InMemoryDatabase.Pets.Max(x => x.Id) + 1
                : 1;

            InMemoryDatabase.Pets.Add(pet);
            return Task.FromResult(pet);
        }

        public Task<bool> DeleteAsync(int id)
        {
            var pet = InMemoryDatabase.Pets.FirstOrDefault(x => x.Id == id);
            if (pet is null)
                return Task.FromResult(false);

            InMemoryDatabase.Pets.Remove(pet);
            return Task.FromResult(true);
        }

        public Task<IEnumerable<Pet>> GetAllAsync()
        {
            return Task.FromResult(InMemoryDatabase.Pets.AsEnumerable());
        }

        public Task<Pet?> GetByIdAsync(int id)
        {
            var pet = InMemoryDatabase.Pets.FirstOrDefault(x => x.Id == id);
            return Task.FromResult(pet);
        }

        public Task<IEnumerable<Pet>> GetByClienteIdAsync(int clienteId)
        {
            var pets = InMemoryDatabase.Pets.Where(x => x.ClienteId == clienteId);
            return Task.FromResult(pets);
        }

        public Task<Pet?> UpdateAsync(int id, Pet pet)
        {
            var existing = InMemoryDatabase.Pets.FirstOrDefault(x => x.Id == id);
            if (existing is null)
                return Task.FromResult<Pet?>(null);

            existing.Nome = pet.Nome;
            existing.Especie = pet.Especie;
            existing.Raca = pet.Raca;
            existing.Peso = pet.Peso;
            existing.DataNascimento = pet.DataNascimento;
            existing.Cor = pet.Cor;
            existing.Sexo = pet.Sexo;
            existing.NumeroMicrochip = pet.NumeroMicrochip;
            existing.DataAtualizacao = DateTime.UtcNow;
            existing.Ativo = pet.Ativo;

            return Task.FromResult<Pet?>(existing);
        }
    }
}

