using AgendamentoVeterinario.Consultas.API.Application.DTO;
using AgendamentoVeterinario.Consultas.API.Application.UseCases;
using AgendamentoVeterinario.Consultas.API.Domain.Entities;
using AgendamentoVeterinario.Consultas.API.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace AgendamentoVeterinario.Consultas.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AgendamentosController : ControllerBase
    {
        private readonly IAgendamentoRepository _repository;
        private readonly AgendarConsultaUseCase _agendarConsultaUseCase;

        public AgendamentosController(IAgendamentoRepository repository, AgendarConsultaUseCase agendarConsultaUseCase)
        {
            _repository = repository;
            _agendarConsultaUseCase = agendarConsultaUseCase;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _repository.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var item = await _repository.GetByIdAsync(id);
            if (item is null) return NotFound();
            return Ok(item);
        }

        [HttpGet("cliente/{clienteId}")]
        public async Task<IActionResult> GetByCliente(int clienteId) => Ok(await _repository.GetByClienteIdAsync(clienteId));

        [HttpGet("veterinario/{veterinarioId}")]
        public async Task<IActionResult> GetByVeterinario(int veterinarioId) => Ok(await _repository.GetByVeterinarioIdAsync(veterinarioId));

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AgendamentoDto dto)
        {
            try
            {
               
                var novoAgendamento = await _agendarConsultaUseCase.ExecutarAsync(
                    dto.ClienteId,
                    dto.PetId,
                    dto.VeterinarioId,
                    dto.DataHoraAgendamento,
                    dto.TipoServico,
                    dto.Valor,
                    dto.Descricao,
                    dto.Observacoes
                );

                return CreatedAtAction(nameof(GetById), new { id = novoAgendamento.Id }, novoAgendamento);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { mensagem = ex.Message });
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { mensagem = ex.Message });
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Agendamento agendamento)
        {
            var updated = await _repository.UpdateAsync(id, agendamento);
            if (updated is null) return NotFound();
            return Ok(updated);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var removed = await _repository.DeleteAsync(id);
            if (!removed) return NotFound();
            return NoContent();
        }
    }
}