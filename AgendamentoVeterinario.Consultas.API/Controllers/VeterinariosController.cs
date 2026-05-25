using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using AgendamentoVeterinario.Consultas.API.Domain.Entities;
using AgendamentoVeterinario.Consultas.API.Domain.Repositories;
using AgendamentoVeterinario.Consultas.API.Application.DTOs;

namespace AgendamentoVeterinario.Consultas.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VeterinariosController : ControllerBase
    {
        private readonly IVeterinarioRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public VeterinariosController(IVeterinarioRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
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
        public async Task<IActionResult> Create([FromBody] VeterinarioDto dto)
        {
            var veterinario = new Veterinario(dto.Nome, dto.CRMV, dto.Email, dto.Telefone, dto.Especialidade);

            await _unitOfWork.BeginTransactionAsync();
            try
            {
                var created = await _repository.AddAsync(veterinario);
                await _unitOfWork.CommitAsync();

                return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
            }
            catch
            {
                await _unitOfWork.RollbackAsync();
                throw;
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] VeterinarioDto dto)
        {
            var veterinario = new Veterinario(dto.Nome, dto.CRMV, dto.Email, dto.Telefone, dto.Especialidade);

            await _unitOfWork.BeginTransactionAsync();
            try
            {
                var updated = await _repository.UpdateAsync(id, veterinario);
                if (updated is null) return NotFound();

                await _unitOfWork.CommitAsync();
                return Ok(updated);
            }
            catch
            {
                await _unitOfWork.RollbackAsync();
                throw;
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _unitOfWork.BeginTransactionAsync();
            try
            {
                var removed = await _repository.DeleteAsync(id);
                if (!removed) return NotFound();

                await _unitOfWork.CommitAsync();
                return NoContent();
            }
            catch
            {
                await _unitOfWork.RollbackAsync();
                throw;
            }
        }
    }
}