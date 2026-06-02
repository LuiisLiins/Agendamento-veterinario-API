using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Agendamento_Veterinario___Back.Domain.Entities;
using Agendamento_Veterinario___Back.Domain.Services;

namespace Agendamento_Veterinario___Back.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VeterinariosController : ControllerBase
    {
        private readonly IVeterinarioService _service;

        public VeterinariosController(IVeterinarioService service)
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

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Veterinario veterinario)
        {
            var created = await _service.CreateAsync(veterinario);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Veterinario veterinario)
        {
            var updated = await _service.UpdateAsync(id, veterinario);
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

