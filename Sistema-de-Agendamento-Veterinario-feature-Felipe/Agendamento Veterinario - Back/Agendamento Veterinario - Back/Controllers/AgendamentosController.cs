using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Agendamento_Veterinario___Back.Domain.Entities;
using Agendamento_Veterinario___Back.Domain.Services;

namespace Agendamento_Veterinario___Back.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AgendamentosController : ControllerBase
    {
        private readonly IAgendamentoService _service;

        public AgendamentosController(IAgendamentoService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _service.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var item = await _service.GetByIdAsync(id);
            if (item is null) return NotFound();
            return Ok(item);
        }

        [HttpGet("cliente/{clienteId}")]
        public async Task<IActionResult> GetByCliente(int clienteId) => Ok(await _service.GetByClienteIdAsync(clienteId));

        [HttpGet("veterinario/{veterinarioId}")]
        public async Task<IActionResult> GetByVeterinario(int veterinarioId) => Ok(await _service.GetByVeterinarioIdAsync(veterinarioId));

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Agendamento agendamento)
        {
            var created = await _service.CreateAsync(agendamento);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Agendamento agendamento)
        {
            var updated = await _service.UpdateAsync(id, agendamento);
            if (updated is null) return NotFound();
            return Ok(updated);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var removed = await _service.DeleteAsync(id);
            if (!removed) return NotFound();
            return NoContent();
        }
    }
}

