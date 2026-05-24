using System;
using System.Threading.Tasks;
using AgendamentoVeterinario.Cadastro.API.Domain.Entities;
using AgendamentoVeterinario.Cadastro.API.Domain.Repositories;

namespace AgendamentoVeterinario.Cadastro.API.Application.UseCases
{
    public class CadastrarPetUseCase
    {
        private readonly IPetRepository _petRepository;

        public CadastrarPetUseCase(IPetRepository petRepository)
        {
            _petRepository = petRepository;
        }

        public async Task<Pet> ExecutarAsync(int clienteId, string nome, string especie, string raca, decimal peso, DateTime dataNascimento, string cor, string sexo, string numeroMicrochip)
        {
            var novoPet = new Pet(clienteId, nome, especie, raca, peso, dataNascimento, cor, sexo, numeroMicrochip);
            return await _petRepository.AddAsync(novoPet);
        }
    }
}