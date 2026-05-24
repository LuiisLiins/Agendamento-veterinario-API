using Microsoft.AspNetCore.Mvc;

namespace AgendamentoVeterinario.Consultas.API.Controllers
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
                new { Id = 2, Nome = "Vacinacao", Valor = 80m },
                new { Id = 3, Nome = "Cirurgia", Valor = 500m }
            };


            return Ok(servicos);
        }
    }
}