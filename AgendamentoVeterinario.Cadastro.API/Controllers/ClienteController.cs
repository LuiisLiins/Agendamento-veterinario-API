using AgendamentoVeterinario.Cadastro.API.Application.DTOs;
using AgendamentoVeterinario.Cadastro.API.Application.UseCases;
using AgendamentoVeterinario.Cadastro.API.Domain.Entities;
using AgendamentoVeterinario.Cadastro.API.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace AgendamentoVeterinario.Cadastro.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientesController : ControllerBase
    {
        private readonly IClienteRepository _repository;
        private readonly RegistrarClienteUsuarioUseCase _registrarClienteUsuarioUseCase;
        private readonly DesativarClienteUsuarioUseCase _desativarClienteUsuarioUseCase;
        private readonly IUnitOfWork _unitOfWork;

        public ClientesController(
            IClienteRepository repository,
            RegistrarClienteUsuarioUseCase registrarClienteUsuarioUseCase,
            DesativarClienteUsuarioUseCase desativarClienteUsuarioUseCase,
            IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _registrarClienteUsuarioUseCase = registrarClienteUsuarioUseCase;
            _desativarClienteUsuarioUseCase = desativarClienteUsuarioUseCase;
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
        public async Task<IActionResult> Create([FromBody] ClienteUsuarioDto dto)
        {
            try
            {
                var created = await _registrarClienteUsuarioUseCase.ExecutarAsync(
                    dto.Nome, dto.Email, dto.Senha, dto.CPF, dto.Telefone,
                    dto.Endereco, dto.Cidade, dto.Estado, dto.CEP
                );

                return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { mensagem = ex.Message });
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] ClienteDto dto)
        {
            var itemExistente = await _repository.GetByIdAsync(id);
            if (itemExistente is null) return NotFound();

            var clienteAtualizado = new Cliente(dto.CPF, dto.Telefone, dto.Endereco, dto.Cidade, dto.Estado, dto.CEP, itemExistente.UsuarioId);

            await _unitOfWork.BeginTransactionAsync();
            try
            {
                var updated = await _repository.UpdateAsync(id, clienteAtualizado);
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
            try
            {
                await _desativarClienteUsuarioUseCase.ExecutarAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                if (ex.Message == "Cliente não encontrado.") return NotFound();
                return BadRequest(new { mensagem = ex.Message });
            }
        }
    }
}