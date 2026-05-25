using System;
using System.Threading.Tasks;
using AgendamentoVeterinario.Consultas.API.Domain.Entities;
using AgendamentoVeterinario.Consultas.API.Domain.Repositories;

namespace AgendamentoVeterinario.Consultas.API.Application.UseCases
{
    public class AgendarConsultaUseCase
    {
        private readonly IAgendamentoRepository _agendamentoRepository;
        private readonly IUnitOfWork _unitOfWork;

        public AgendarConsultaUseCase(IAgendamentoRepository agendamentoRepository, IUnitOfWork unitOfWork)
        {
            _agendamentoRepository = agendamentoRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Agendamento> ExecutarAsync(int clienteId, int petId, int veterinarioId, DateTime dataHora, string tipoServico, decimal valor, string descricao, string observacoes)
        {
            var agendamentosExistentes = await _agendamentoRepository.GetByVeterinarioIdAsync(veterinarioId);

            foreach (var existente in agendamentosExistentes)
            {
                if (existente.ValidarConflitoHorario(dataHora))
                {
                    throw new InvalidOperationException("O veterinário já possui uma consulta agendada neste horário.");
                }
            }

            var novoAgendamento = new Agendamento(clienteId, petId, veterinarioId, dataHora, tipoServico, valor, descricao, observacoes);

            await _unitOfWork.BeginTransactionAsync();

            try
            {
                await _agendamentoRepository.AddAsync(novoAgendamento);
                await _unitOfWork.CommitAsync();

                return novoAgendamento;
            }
            catch
            {
                await _unitOfWork.RollbackAsync();
                throw;
            }
        }
    }
}