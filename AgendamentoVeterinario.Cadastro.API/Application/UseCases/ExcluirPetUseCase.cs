using System;
using System.Threading.Tasks;
using AgendamentoVeterinario.Cadastro.API.Domain.Repositories;

namespace AgendamentoVeterinario.Cadastro.API.Application.UseCases
{
    public class ExcluirPetUseCase
    {
        private readonly IPetRepository _petRepository;

        public ExcluirPetUseCase(IPetRepository petRepository)
        {
            _petRepository = petRepository;
        }

        public async Task ExecutarAsync(int petId)
        {
            var pet = await _petRepository.GetByIdAsync(petId);
            if (pet == null)
            {
                throw new InvalidOperationException("Pet nao encontrado.");
            }

            bool possuiConsultasAtivas = await _petRepository.ExisteConsultaFuturaParaOPetAsync(petId);

            if (!pet.ValidarSePodeSerExcluido(possuiConsultasAtivas))
            {
                throw new InvalidOperationException("Nao e permitido excluir um pet com consultas futuras agendadas.");
            }

            await _petRepository.DeleteAsync(petId);
        }
    }
}