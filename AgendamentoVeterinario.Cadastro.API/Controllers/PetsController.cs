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
    public class PetsController : ControllerBase
    {
        private readonly IPetRepository _repository;
        private readonly CadastrarPetUseCase _cadastrarPetUseCase;
        private readonly ExcluirPetUseCase _excluirPetUseCase;

        public PetsController(IPetRepository repository, CadastrarPetUseCase cadastrarPetUseCase, ExcluirPetUseCase excluirPetUseCase)
        {
            _repository = repository;
            _cadastrarPetUseCase = cadastrarPetUseCase;
            _excluirPetUseCase = excluirPetUseCase;
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

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] PetDto dto)
        {
            var created = await _cadastrarPetUseCase.ExecutarAsync(
                dto.ClienteId, 
                dto.Nome, 
                dto.Especie, 
                dto.Raca, 
                dto.Peso,
                dto.DataNascimento, 
                dto.Cor, 
                dto.Sexo, 
                dto.NumeroMicrochip
            );
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] PetDto dto)
        {
            var pet = new Pet(
                dto.ClienteId,
                dto.Nome,
                dto.Especie,
                dto.Raca,
                dto.Peso,
                dto.DataNascimento,
                dto.Cor,
                dto.Sexo,
                dto.NumeroMicrochip
            );

            var updated = await _repository.UpdateAsync(id, pet);
            if (updated is null) return NotFound();
            return Ok(updated);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _excluirPetUseCase.ExecutarAsync(id);
                return NoContent();
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { mensagem = ex.Message });
            }
        }
    }
}