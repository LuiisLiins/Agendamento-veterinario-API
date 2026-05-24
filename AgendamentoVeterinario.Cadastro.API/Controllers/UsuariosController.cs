using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using AgendamentoVeterinario.Cadastro.API.Domain.Entities;
using AgendamentoVeterinario.Cadastro.API.Domain.Repositories;
using AgendamentoVeterinario.Cadastro.API.Application.UseCases;
using AgendamentoVeterinario.Cadastro.API.Application.DTOs;

namespace AgendamentoVeterinario.Cadastro.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuarioRepository _repository;
        private readonly RegistrarUsuarioUseCase _registrarUsuarioUseCase;
        private readonly DesativarUsuarioUseCase _desativarUsuarioUseCase;

        public UsuariosController(
            IUsuarioRepository repository,
            RegistrarUsuarioUseCase registrarUsuarioUseCase,
            DesativarUsuarioUseCase desativarUsuarioUseCase
            )
        {
            _repository = repository;
            _registrarUsuarioUseCase = registrarUsuarioUseCase;
            _desativarUsuarioUseCase = desativarUsuarioUseCase;
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

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] UsuarioDto dto)
        {
            try
            {
                var created = await _registrarUsuarioUseCase.ExecutarAsync
                (
                    dto.Nome,
                    dto.Email,
                    dto.SenhaHash
                );

                return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { mensagem = ex.Message });
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UsuarioDto dto)
        {
            var usuario = new Usuario
            (
                dto.Nome,
                dto.Email,
                dto.SenhaHash
            );

            var updated = await _repository.UpdateAsync(id, usuario);
            if (updated is null) return NotFound();
            return Ok(updated);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                await _desativarUsuarioUseCase.ExecutarAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                if (ex.Message == "Usuário não encontrado.") return NotFound();
                return BadRequest(new { mensagem = ex.Message });
            }
        }
    }
}