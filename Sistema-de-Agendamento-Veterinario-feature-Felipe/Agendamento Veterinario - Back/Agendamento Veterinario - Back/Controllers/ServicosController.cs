using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Agendamento_Veterinario___Back.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ServicosController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAll()
        {
            var servicos = new List<object>
            {
                new { Id = 1, Nome = "Consulta" , Valor = 100m },
                new { Id = 2, Nome = "Vacinação", Valor = 80m },
                new { Id = 3, Nome = "Cirurgia", Valor = 500m }
            };

            return Ok(servicos);
        }
    }
}
