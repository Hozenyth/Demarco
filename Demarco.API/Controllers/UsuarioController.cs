using Demarco.Application.Interfaces;
using Demarco.Application.Validators;
using Demarco.Domain;
using Demarco.DTOs;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Demarco.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : Controller
    {
        private readonly IUsuarioApp _app;
        public UsuarioController(IUsuarioApp app)
        {
            this._app = app;
        }

        [HttpPost]
        [ProducesResponseType(typeof(UsuarioDTO), (int)HttpStatusCode.Created)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> Post(UsuarioDTO usuario)
        {
            try
            {
                var validator = new UsuarioDTOValidator();
                var validationResult = await validator.ValidateAsync(usuario);

                if (!validationResult.IsValid)
                {
                    var mensagemErro = string.Join(" ", validationResult.Errors.Select(e => e.ErrorMessage));
                    return StatusCode(StatusCodes.Status400BadRequest, mensagemErro);
                }
               
                var sucesso = await _app.Salvar(usuario);

                if (sucesso)
                {
                    return StatusCode(StatusCodes.Status201Created, "Usuário cadastrado");
                }

                return BadRequest(new { Message = "Erro ao cadastrar usuário ." });

            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);

            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDTO login)
        {
            var sucesso = await _app.Login(login);

            if (sucesso != null)
            {

                return StatusCode(StatusCodes.Status201Created, sucesso.Token);
               
            }           

            return StatusCode(StatusCodes.Status401Unauthorized, "Usuário não autorizado");
        }
    }
}
