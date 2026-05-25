using System;
using System.Threading.Tasks;
using AgendamentoVeterinario.Cadastro.API.Domain.Repositories;

namespace AgendamentoVeterinario.Cadastro.API.Application.UseCases
{
    public class ExcluirPetUseCase
    {
        private readonly IPetRepository _petRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ExcluirPetUseCase(IPetRepository petRepository, IUnitOfWork unitOfWork)
        {
            _petRepository = petRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task ExecutarAsync(int petId)
        {
            var pet = await _petRepository.GetByIdAsync(petId);
            if (pet == null)
            {
                throw new InvalidOperationException("Pet não encontrado.");
            }

            bool possuiConsultasAtivas = await _petRepository.ExisteConsultaFuturaParaOPetAsync(petId);

            if (!pet.ValidarSePodeSerExcluido(possuiConsultasAtivas))
            {
                throw new InvalidOperationException("Não é permitido excluir um pet com consultas futuras agendadas.");
            }

            await _unitOfWork.BeginTransactionAsync();

            try
            {
                await _petRepository.DeleteAsync(petId);
                await _unitOfWork.CommitAsync();
            }
            catch
            {
                await _unitOfWork.RollbackAsync();
                throw;
            }
        }
    }
}