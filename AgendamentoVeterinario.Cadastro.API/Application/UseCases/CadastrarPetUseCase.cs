using System;
using System.Threading.Tasks;
using AgendamentoVeterinario.Cadastro.API.Domain.Entities;
using AgendamentoVeterinario.Cadastro.API.Domain.Repositories;

namespace AgendamentoVeterinario.Cadastro.API.Application.UseCases
{
    public class CadastrarPetUseCase
    {
        private readonly IPetRepository _petRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CadastrarPetUseCase(IPetRepository petRepository, IUnitOfWork unitOfWork)
        {
            _petRepository = petRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Pet> ExecutarAsync(int clienteId, string nome, string especie, string raca, decimal peso, DateTime dataNascimento, string cor, string sexo, string numeroMicrochip)
        {
            var novoPet = new Pet(clienteId, nome, especie, raca, peso, dataNascimento, cor, sexo, numeroMicrochip);

            await _unitOfWork.BeginTransactionAsync();

            try
            {
                await _petRepository.AddAsync(novoPet);
                await _unitOfWork.CommitAsync();

                return novoPet;
            }
            catch
            {
                await _unitOfWork.RollbackAsync();
                throw;
            }
        }
    }
}