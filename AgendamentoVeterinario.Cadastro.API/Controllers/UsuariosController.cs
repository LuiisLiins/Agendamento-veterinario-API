using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using AgendamentoVeterinario.Cadastro.API.Domain.Entities;
using AgendamentoVeterinario.Cadastro.API.Domain.Repositories;
using AgendamentoVeterinario.Cadastro.API.Application.DTOs;

namespace AgendamentoVeterinario.Cadastro.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuarioRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public UsuariosController(IUsuarioRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _repository.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var item = await _repository.GetByIdAsync(id);
            if (item is null) return NotFound();
            return Ok(item);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UsuarioDto dto)
        {
            var usuario = new Usuario(dto.Nome, dto.Email, dto.Senha);

            await _unitOfWork.BeginTransactionAsync();
            try
            {
                var updated = await _repository.UpdateAsync(id, usuario);
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
    }
}