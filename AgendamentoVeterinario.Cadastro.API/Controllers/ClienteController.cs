using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using AgendamentoVeterinario.Cadastro.API.Domain.Repositories;
using AgendamentoVeterinario.Cadastro.API.Application.UseCases;
using AgendamentoVeterinario.Cadastro.API.Application.DTOs;

namespace AgendamentoVeterinario.Cadastro.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientesController : ControllerBase
    {

        private readonly IClienteRepository _repository;
        private readonly RegistrarClienteUseCase _registrarClienteUseCase;

        public ClientesController(IClienteRepository repository, RegistrarClienteUseCase registrarClienteUseCase)
        {
            _repository = repository;
            _registrarClienteUseCase = registrarClienteUseCase;
        }

        private readonly IClienteRepository _repository;
        private readonly RegistrarClienteUseCase _registrarClienteUseCase;

        public ClientesController(IClienteRepository repository, RegistrarClienteUseCase registrarClienteUseCase)
        {
            _repository = repository;
            _registrarClienteUseCase = registrarClienteUseCase;
        }