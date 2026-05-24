using System;
using System.Threading.Tasks;
using AgendamentoVeterinario.Consultas.API.Domain.Entities;
using AgendamentoVeterinario.Consultas.API.Domain.Repositories;

namespace AgendamentoVeterinario.Consultas.API.Application.UseCases
{
    public class AgendarConsultaUseCase
    {
        private readonly IAgendamentoRepository _agendamentoRepository;

        public AgendarConsultaUseCase(IAgendamentoRepository agendamentoRepository)
        {
            _agendamentoRepository = agendamentoRepository;
        }

        public async Task<Agendamento> ExecutarAsync(int clienteId, int petId, int veterinarioId, DateTime dataHora, string tipoServico, decimal valor, string descricao, string observacoes)
        {
            var agendamentosExistentes = await _agendamentoRepository.GetByVeterinarioIdAsync(veterinarioId);

            foreach (var existente in agendamentosExistentes)
            {
                if (existente.ValidarConflitoHorario(dataHora))
                {
                    throw new InvalidOperationException("O veterinario ja possui uma consulta agendada neste horario.");
                }
            }

            var novoAgendamento = new Agendamento(clienteId, petId, veterinarioId, dataHora, tipoServico, valor, descricao, observacoes);
            return await _agendamentoRepository.AddAsync(novoAgendamento);
        }
    }
}