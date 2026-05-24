using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using AgendamentoVeterinario.Consultas.API.Domain.Entities;
using AgendamentoVeterinario.Consultas.API.Domain.Repositories;

namespace AgendamentoVeterinario.Consultas.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VeterinariosController : ControllerBase
    {
        private readonly IVeterinarioRepository _repository;

        public VeterinariosController(IVeterinarioRepository repository)
        {
            _repository = repository;
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

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Veterinario veterinario)
        {
            var created = await _repository.AddAsync(veterinario);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Veterinario veterinario)
        {
            var updated = await _repository.UpdateAsync(id, veterinario);
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