using Demarco.Application.Interfaces;
using Demarco.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading.Tasks;

namespace Demarco.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmpregadoController : Controller
    {
        private readonly IEmpregadoApp _app;
        public EmpregadoController(IEmpregadoApp app)
        {
            this._app = app;
        }

        [HttpGet]
        [ProducesResponseType(typeof(EmpregadoDTO[]), (int)HttpStatusCode.OK)]
        public IActionResult Get()
        {
            try
            {
                return Ok(_app.RecuperarTodos());
            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);

            }
        }

        [HttpPost]
        [ProducesResponseType(typeof(EmpregadoDTO), (int)HttpStatusCode.Created)]
        public async Task<IActionResult> Post(EmpregadoDTO empregado)
        {
            try
            {
                if (await _app.Salvar(empregado))
                {
                    return this.StatusCode(StatusCodes.Status201Created, "Empregado Criado");
                }
                return BadRequest();
            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);

            }
        }
    }
}
