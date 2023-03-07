using ExerciciosCMU.Domain.DTOs.Request;
using ExerciciosCMU.Domain.Interfaces;
using ExerciciosCMU.Domain.Utils;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using ExerciciosCMU.Domain.Extensions;
namespace ExerciciosCMU.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ExerciciosController : ControllerBase
    {
        private readonly IExercicios _services;

        public ExerciciosController(IExercicios services)
        {
            _services = services;
        }

        [HttpPost("Exercicio-1")]
        [SwaggerOperation(Summary = "Filtrar palavras terminadas em A")]
        public IActionResult Exercicio_1(Exercicio1Request list)
        {
            APIMessage result = _services.FiltraTerminadasEmA(list.palavras);
            return StatusCode((int)result.StatusCode, result.Content);
        }

        [HttpPost("Exercicio-2")]
        [SwaggerOperation(Summary = "Contar aparições")]
        public IActionResult Exercicio_2(Exercicio2Request request)
        {
            APIMessage result = _services.ContaAparicoes(request.Frase, request.Palavra);
            return StatusCode((int)result.StatusCode, result.Content);
        }

        [HttpPost("Exercicio-3")]
        [SwaggerOperation(Summary = "Contar dias")]
        public IActionResult Exercicio_3(Exercicio3Request request)
        {
            APIMessage result = _services.ContaDias(request.data1, request.data2);
            return StatusCode((int)result.StatusCode, result.Content);
        }

        [HttpPost("Exercicio-4")]
        [SwaggerOperation(Summary = "Ordenar usuários")]
        public IActionResult Exercicio_4(UsuarioListRequest request)
        {
            APIMessage result = _services.OrdenaUsuario(request.Usuarios);
            return StatusCode((int)result.StatusCode, result.Content);
        }

        [HttpPost("Exercicio-5")]
        [SwaggerOperation(Summary = "Identificar duplicatas")]
        public IActionResult Exercicio_5(UsuarioListRequest request)
        {
            APIMessage result = _services.IdentificaDuplicados(request.Usuarios);
            return StatusCode((int)result.StatusCode, result.Content);
        }

        [HttpPost("Exercicio-6")]
        [SwaggerOperation(Summary = "Divisor de listas em sub-listas")]
        public IActionResult Exercicio_6(Exercicio6Request request)
        {
            APIMessage result = _services.QuebraLista(request.integers,request.listNumber);
            return StatusCode((int)result.StatusCode, result.Content);
        }

        [HttpGet("Exercicio-8")]
        [SwaggerOperation(Summary = "Desafio final!")]
        public IActionResult Exercicio_8()
        {
            IEnumerable<Veiculo> veiculos = _services.PopularVeiculos();
            APIMessage result = _services.FrotaVeiculos(veiculos);
            return StatusCode((int)result.StatusCode, result.Content);
        }


    }
}
